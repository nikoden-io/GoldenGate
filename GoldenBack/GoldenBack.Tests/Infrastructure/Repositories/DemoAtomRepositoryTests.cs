// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Nikoden.IO All rights reserved.
//     Author: Nicolas Denoël
// </copyright>
// -----------------------------------------------------------------------

using Domain.Entities;
using FluentAssertions;
using GoldenBack.Infrastructure.DbContext;
using GoldenBack.Infrastructure.Repositories;
using GoldenBack.Tests.Builders;
using Microsoft.EntityFrameworkCore;

namespace GoldenBack.Tests.Infrastructure.Repositories;

public class DemoAtomRepositoryTests
{
    private readonly ApplicationDbContext _context;
    private readonly DemoAtomRepository _repository;

    public DemoAtomRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            // Use GUID to avoid conflicts by sharing data between unit tests
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _context = new ApplicationDbContext(options);
        _repository = new DemoAtomRepository(_context);
    }

    [Fact]
    public async Task AddDemoAtomAsync_Should_Add_DemoAtom()
    {
        // Arrange
        var demoAtom = new DemoAtomBuilder()
            .WithId("507f1f77bcf86cd799439112")
            .WithDemoFieldOne("Test field")
            .WithIsDemo(true)
            .Build();

        // Act 
        await _repository.AddDemoAtomAsync(demoAtom);

        // Assert
        var result = await _context.DemoAtoms.FindAsync(demoAtom.Id);
        result.Should().NotBeNull();
        result.DemoFieldOne.Should().Be("Test field");
        result.IsDemo.Should().BeTrue();
    }

    [Fact]
    public async Task GetDemoAtomByIdAsync_Should_Return_DemoAtom_When_Found()
    {
        // Arrange
        var demoAtom = new DemoAtomBuilder()
            .WithId("507f1f77bcf86cd799439112")
            .WithDemoFieldOne("Test field")
            .WithIsDemo(true)
            .Build();

        _context.DemoAtoms.Add(demoAtom);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetDemoAtomByIdAsync(demoAtom.Id);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(demoAtom.Id);
    }

    [Fact]
    public async Task GetAllDemoAtomsAsync_Should_Return_All_DemoAtoms()
    {
        // Arrange
        _context.DemoAtoms.AddRange(new List<DemoAtom>
        {
            new DemoAtomBuilder()
                .WithId("507f1f77bcf86cd799439112")
                .WithDemoFieldOne("Test field one")
                .WithIsDemo(true)
                .Build(),
            new DemoAtomBuilder()
                .WithId("507f1f77bcf86cd799439014")
                .WithDemoFieldOne("Test field two")
                .WithIsDemo(false)
                .Build()
        });
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllDemoAtomsAsync();

        // Assert
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task UpdateDemoAtomAsync_Should_Update_DemoAtom()
    {
        // Arrange
        var demoAtom = new DemoAtomBuilder()
            .WithId("507f1f77bcf86cd799439112")
            .WithDemoFieldOne("Test field")
            .WithIsDemo(true)
            .Build();

        _context.DemoAtoms.Add(demoAtom);
        await _context.SaveChangesAsync();

        demoAtom.DemoFieldOne = "New Field";

        // Act
        await _repository.UpdateDemoAtomAsync(demoAtom);

        // Assert
        var result = await _context.DemoAtoms.FindAsync(demoAtom.Id);
        result.DemoFieldOne.Should().Be("New Field");
    }

    [Fact]
    public async Task DeleteDemoAtomAsync_Should_Remove_DemoAtom()
    {
        // Arrange
        var demoAtom = new DemoAtomBuilder()
            .WithId("507f1f77bcf86cd799439112")
            .WithDemoFieldOne("Test field")
            .WithIsDemo(true)
            .Build();

        _context.DemoAtoms.Add(demoAtom);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.DeleteDemoAtomAsync(demoAtom.Id);

        // Assert
        result.Should().BeTrue();
        var deletedDemoAtom = await _context.DemoAtoms.FindAsync(demoAtom.Id);
        deletedDemoAtom.Should().BeNull();
    }
}