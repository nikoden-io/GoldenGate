// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Domintell s.a. All rights reserved.
//     Author: Nicolas Denoël
//     Description: MongoDB repository implementation to manage demoAtoms.
// </copyright>
// -----------------------------------------------------------------------

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace GoldenBack.Infrastructure.DbContext;

/// <summary>
///     Represents the database context for the application.
/// </summary>
public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<DemoAtom> DemoAtoms { get; set; }

    /// <summary>
    ///     Configures the entity mappings and database settings.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DemoAtom>(entity =>
        {
            entity.ToCollection("DemoAtoms");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasConversion<string>()
                .IsRequired();

            entity.Property(e => e.DemoFieldOne)
                .IsRequired();

            entity.Property(e => e.IsDemo)
                .IsRequired();
        });
    }
}