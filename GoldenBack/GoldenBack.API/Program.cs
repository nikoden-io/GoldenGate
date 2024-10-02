// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Nikoden.IO All rights reserved.
//     Author: Nicolas Denoël
// </copyright>
// -----------------------------------------------------------------------

using Application.Interfaces.ApplicationServices;
using Application.Mappings;
using Application.Services.AppServices;
using AutoMapper;
using GoldenBack.API.Routing;
using GoldenBack.Domain.IRepositories;
using GoldenBack.Infrastructure.DbContext;
using GoldenBack.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

// Logging
builder.Services.AddLogging(loggingBuilder => { loggingBuilder.AddConsole(); });

// Mapping
builder.Services.AddAutoMapper(typeof(MappingProfile));

// CORS Management
/***
 * localhost:5173 : Development Local Web Client
 * 127.0.0.1 : Localhost
 */
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins(
                    "http://localhost:5173", "https://localhost:5173",
                    "http://127.0.0.1")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

// HTTP session 
builder.Services.AddSession(options =>
{
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Redis
builder.Services.AddDistributedMemoryCache();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["Redis:Configuration"];
});

builder.Services.AddEndpointsApiExplorer();

// Configure MongoDB settings
builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection(nameof(MongoSettings)));

// Register MongoDB EF Context
builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
{
    var mongoSettings = serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value;
    var client = new MongoClient(mongoSettings.ConnectionString);
    options.UseMongoDB(client, mongoSettings.DatabaseName);
});

// Controllers injection
builder.Services.AddControllers(options => { options.Conventions.Add(new VersionRouteConvention()); });

// Application Services DI
builder.Services.AddScoped<IDemoAtomAppService>(serviceProvider =>
{
    var demoAtomRepository = serviceProvider.GetRequiredService<IDemoAtomRepository>();
    var mapper = serviceProvider.GetRequiredService<IMapper>();
    var logger = serviceProvider.GetRequiredService<ILogger<DemoAtomAppService>>();

    return new DemoAtomAppService(demoAtomRepository, mapper, logger);
});

// Infrastructure Services DI

// Repository injection
builder.Services.AddScoped<IDemoAtomRepository, DemoAtomRepository>();

var app = builder.Build();

if (app.Environment.IsProduction()) app.UseHttpsRedirection();

app.MapControllers();
app.UseCors();
app.UseSession();


// Log routing for debug purpose
if (app.Environment.IsDevelopment())
    app.Use(async (context, next) =>
    {
        Console.WriteLine("Requested Path: " + context.Request.Path);
        await next();
    });


app.Run();

public class MongoSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}