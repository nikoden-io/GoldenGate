// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Nikoden.IO All rights reserved.
//     Author: Nicolas Denoël
// </copyright>
// -----------------------------------------------------------------------

using Application.DTO;
using Application.DTO.ApplicationDTO;
using Application.Interfaces.ApplicationServices;
using Asp.Versioning;
using GoldenBack.API.Constants;
using Microsoft.AspNetCore.Mvc;

namespace GoldenBack.API.Controllers;

/// <summary>
///     Manages HTTP requests for DemoAtom-related operations.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/demoatom")]
public class DemoAtomController : ControllerBase
{
    private readonly IDemoAtomAppService _demoAtomAppService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DemoAtomController" />.
    /// </summary>
    /// <param name="demoAtomAppService">Service for demoAtom-related functionality</param>
    public DemoAtomController(IDemoAtomAppService demoAtomAppService)
    {
        _demoAtomAppService = demoAtomAppService;
    }

    /// <summary>
    ///     Creates a new DemoAtom.
    /// </summary>
    /// <param name="demoAtomDto">The DemoAtom data transfer object.</param>
    [HttpPost]
    public async Task<IActionResult> AddDemoAtomAsync([FromBody] CreateDemoAtomDTO demoAtomDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ApiResponse<CreateDemoAtomDTO>.ErrorResponse(Messages.CreationFailed));

        var response = await _demoAtomAppService.AddDemoAtomAsync(demoAtomDto);
        return Ok(ApiResponse<DemoAtomDTO>.SuccessResponse(response, Messages.CreationSuccess));
    }


    /// <summary>
    ///     Retrieves all DemoAtoms.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllDemoAtomsAsync()
    {
        var demoAtoms = await _demoAtomAppService.GetAllDemoAtomsAsync();
        return Ok(ApiResponse<List<DemoAtomDTO>>.SuccessResponse(demoAtoms, Messages.FetchSuccess));
    }

    /// <summary>
    ///     Retrieves a specific DemoAtom by ID.
    /// </summary>
    /// <param name="id">The ID of the DemoAtom to retrieve.</param>
    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> GetDemoAtomByIdAsync(string id)
    {
        var demoAtom = await _demoAtomAppService.GetDemoAtomByIdAsync(id);
        if (demoAtom == null)
            return NotFound(ApiResponse<DemoAtomDTO>.ErrorResponse(Messages.NotFound));

        return Ok(ApiResponse<DemoAtomDTO>.SuccessResponse(demoAtom, Messages.FetchSuccess));
    }

    /// <summary>
    ///     Updates an existing DemoAtom.
    /// </summary>
    /// <param name="id">The ID of the DemoAtom to update.</param>
    /// <param name="demoAtomDto">The updated DemoAtom data transfer object.</param>
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> UpdateDemoAtomAsync(string id, [FromBody] DemoAtomDTO demoAtomDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ApiResponse<DemoAtomDTO>.ErrorResponse(Messages.UpdateFailed));

        var updatedDemoAtom = await _demoAtomAppService.UpdateDemoAtomAsync(id, demoAtomDto);
        if (updatedDemoAtom == null)
            return NotFound(ApiResponse<DemoAtomDTO>.ErrorResponse(Messages.NotFound));

        return Ok(ApiResponse<DemoAtomDTO>.SuccessResponse(updatedDemoAtom, Messages.UpdateSuccess));
    }

    /// <summary>
    ///     Deletes a DemoAtom.
    /// </summary>
    /// <param name="id">The ID of the DemoAtom to delete.</param>
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteDemoAtomAsync(string id)
    {
        var result = await _demoAtomAppService.DeleteDemoAtomAsync(id);
        if (!result)
            return NotFound(ApiResponse<bool>.ErrorResponse(Messages.NotFound));

        return Ok(ApiResponse<bool>.SuccessResponse(true, Messages.DeleteSuccess));
    }
}