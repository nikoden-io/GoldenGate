// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Nikoden.IO All rights reserved.
//     Author: Nicolas Denoël
// </copyright>
// -----------------------------------------------------------------------

using Application.DTO.ApplicationDTO;
using Application.Services.AppServices;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using GoldenBack.Domain.IRepositories;
using GoldenBack.Tests.Builders;
using Microsoft.Extensions.Logging;
using Moq;

namespace GoldenBack.Tests.Application.Services;

public class DemoAtomAppServiceTests
{
    private readonly DemoAtomAppService _demoAtomAppService;
    private readonly Mock<IDemoAtomRepository> _demoAtomRepositoryMock;
    private readonly Mock<ILogger<DemoAtomAppService>> _loggerMock;
    private readonly IMapper _mapper;

    public DemoAtomAppServiceTests()
    {
        _demoAtomRepositoryMock = new Mock<IDemoAtomRepository>();
        _loggerMock = new Mock<ILogger<DemoAtomAppService>>();

        var mapperConfig = new MapperConfiguration(cfg => { cfg.CreateMap<DemoAtom, DemoAtomDTO>().ReverseMap(); });
        _mapper = mapperConfig.CreateMapper();

        _demoAtomAppService = new DemoAtomAppService(_demoAtomRepositoryMock.Object, _mapper, _loggerMock.Object);
    }

    [Fact]
    public async Task AddDemoAsync_Should_Add_New_DemoAtom()
    {
        // Arrange 
        var createDto = new CreateDemoAtomDTOBuilder()
            .WithDemoFieldOne("Test field")
            .WithIsDemo(true)
            .Build();

        // Act
        var result = await _demoAtomAppService.AddDemoAtomAsync(createDto);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().NotBeNullOrEmpty();
        result.DemoFieldOne.Should().Be("Test field");
        result.IsDemo.Should().BeTrue();

        _demoAtomRepositoryMock.Verify(repo => repo.AddDemoAtomAsync(It.IsAny<DemoAtom>()), Times.Once);
    }

    [Fact]
    public async Task GetDemoAtomByIdAsync_Should_Return_DemoAtom_When_Found()
    {
        // Arrange
        var demoAtomId = "507f1f77bcf86cd799439011";
        var demoAtom = new DemoAtomBuilder()
            .WithId(demoAtomId)
            .WithDemoFieldOne("Test Field")
            .WithIsDemo(true)
            .Build();

        _demoAtomRepositoryMock
            .Setup(repo => repo.GetDemoAtomByIdAsync(demoAtomId))
            .ReturnsAsync(demoAtom);

        // Act
        var result = await _demoAtomAppService.GetDemoAtomByIdAsync(demoAtomId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(demoAtomId);
        result.DemoFieldOne.Should().Be("Test Field");
        result.IsDemo.Should().BeTrue();
    }
}