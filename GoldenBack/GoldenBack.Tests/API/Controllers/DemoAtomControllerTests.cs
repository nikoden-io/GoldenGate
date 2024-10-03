// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Nikoden.IO All rights reserved.
//     Author: Nicolas Denoël
// </copyright>
// -----------------------------------------------------------------------

using System.Net;
using System.Text;
using Application.DTO;
using Application.DTO.ApplicationDTO;
using FluentAssertions;
using GoldenBack.Tests.Factories;
using Newtonsoft.Json;

namespace GoldenBack.Tests.API.Controllers;

public class DemoAtomControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public DemoAtomControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task AddDemoAtomAsync_Should_Create_New_DemoAtom()
    {
        // Arrange
        var newDemoAtom = new
        {
            DemoFieldOne = "Test Field controller",
            IsDemo = true
        };

        var content = new StringContent(
            JsonConvert.SerializeObject(newDemoAtom),
            Encoding.UTF8,
            "application/json");

        // Act
        var response = await _client.PostAsync("/v1.0/demoatom", content);

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseContent = await response.Content.ReadAsStringAsync();
        responseContent.Should().NotBeNullOrEmpty();

        // Optionally deserialize and verify the returned object
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<DemoAtomDTO>>(responseContent);
        apiResponse.Data.DemoFieldOne.Should().Be("Test Field controller");
        apiResponse.Data.IsDemo.Should().BeTrue();
        apiResponse.Data.Id.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task DeleteDemoAtomAsync_Should_Remove_DemoAtom()
    {
        // Arrange
        var demoAtom = new DemoAtomDTO
        {
            DemoFieldOne = "Test Field",
            IsDemo = true
        };

        // Create a new DemoAtom
        var postContent = new StringContent(
            JsonConvert.SerializeObject(demoAtom),
            Encoding.UTF8,
            "application/json");

        var postResponse = await _client.PostAsync("/v1.0/demoatom", postContent);
        postResponse.EnsureSuccessStatusCode();

        var postResponseContent = await postResponse.Content.ReadAsStringAsync();
        var createdDemoAtom = JsonConvert.DeserializeObject<ApiResponse<DemoAtomDTO>>(postResponseContent).Data;

        // Act
        var deleteResponse = await _client.DeleteAsync($"/v1.0/demoatom/{createdDemoAtom.Id}");

        // Assert
        deleteResponse.EnsureSuccessStatusCode();
        var deleteResponseContent = await deleteResponse.Content.ReadAsStringAsync();
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<bool>>(deleteResponseContent);

        apiResponse.Data.Should().BeTrue();

        // Verify the DemoAtom no longer exists
        var getResponse = await _client.GetAsync($"/v1.0/demoatom/{createdDemoAtom.Id}");
        getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetDemoAtomByIdAsync_Should_Return_DemoAtom_When_Found()
    {
        // Arrange
        var demoAtom = new DemoAtomDTO
        {
            DemoFieldOne = "Test Field",
            IsDemo = true
        };

        // First, create a new DemoAtom
        var content = new StringContent(
            JsonConvert.SerializeObject(demoAtom),
            Encoding.UTF8,
            "application/json");

        var postResponse = await _client.PostAsync("/v1.0/demoatom", content);
        postResponse.EnsureSuccessStatusCode();

        var postResponseContent = await postResponse.Content.ReadAsStringAsync();
        var createdDemoAtom = JsonConvert.DeserializeObject<ApiResponse<DemoAtomDTO>>(postResponseContent).Data;

        // Act
        var getResponse = await _client.GetAsync($"/v1.0/demoatom/{createdDemoAtom.Id}");

        // Assert
        getResponse.EnsureSuccessStatusCode();
        var getResponseContent = await getResponse.Content.ReadAsStringAsync();
        var retrievedDemoAtom = JsonConvert.DeserializeObject<ApiResponse<DemoAtomDTO>>(getResponseContent).Data;

        retrievedDemoAtom.Should().NotBeNull();
        retrievedDemoAtom.Id.Should().Be(createdDemoAtom.Id);
        retrievedDemoAtom.DemoFieldOne.Should().Be("Test Field");
        retrievedDemoAtom.IsDemo.Should().BeTrue();
    }

    [Fact]
    public async Task GetDemoAtomByIdAsync_Should_Return_NotFound_When_Not_Exists()
    {
        // Arrange
        var nonExistentId = "507f1f77bcf86cd799439011";

        // Act
        var response = await _client.GetAsync($"/v1.0/demoatom/{nonExistentId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetAllDemoAtomsAsync_Should_Return_OK()
    {
        // Act
        var response = await _client.GetAsync("/v1.0/demoatom");

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task UpdateDemoAtomAsync_Should_Update_Existing_DemoAtom()
    {
        // Arrange
        var demoAtom = new DemoAtomDTO
        {
            DemoFieldOne = "Initial Field",
            IsDemo = true
        };

        // Create a new DemoAtom
        var postContent = new StringContent(
            JsonConvert.SerializeObject(demoAtom),
            Encoding.UTF8,
            "application/json");

        var postResponse = await _client.PostAsync("/v1.0/demoatom", postContent);
        postResponse.EnsureSuccessStatusCode();

        var postResponseContent = await postResponse.Content.ReadAsStringAsync();
        var createdDemoAtom = JsonConvert.DeserializeObject<ApiResponse<DemoAtomDTO>>(postResponseContent).Data;

        // Modify the DemoAtom
        createdDemoAtom.DemoFieldOne = "Updated Field";
        var putContent = new StringContent(
            JsonConvert.SerializeObject(createdDemoAtom),
            Encoding.UTF8,
            "application/json");

        // Act
        var putResponse = await _client.PutAsync($"/v1.0/demoatom/{createdDemoAtom.Id}", putContent);

        // Assert
        putResponse.EnsureSuccessStatusCode();
        var putResponseContent = await putResponse.Content.ReadAsStringAsync();
        var updatedDemoAtom = JsonConvert.DeserializeObject<ApiResponse<DemoAtomDTO>>(putResponseContent).Data;

        updatedDemoAtom.DemoFieldOne.Should().Be("Updated Field");
        updatedDemoAtom.IsDemo.Should().BeTrue();
    }
}