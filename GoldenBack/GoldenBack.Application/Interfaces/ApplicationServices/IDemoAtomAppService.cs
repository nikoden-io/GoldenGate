// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Nikoden.IO All rights reserved.
//     Author: Nicolas Denoël
// </copyright>
// -----------------------------------------------------------------------

using Application.DTO.ApplicationDTO;

namespace Application.Interfaces.ApplicationServices;

/// <summary>
///     Provides methods for managing and processing demo atoms.
/// </summary>
public interface IDemoAtomAppService
{
    /// <summary>
    ///     Create and add a DemoAtom entity into the database
    /// </summary>
    /// <param name="demoAtomDto">The DTO that represent all data needed to create DemoAtom entity.</param>
    /// <returns>A task that returns an ApiResponse indicating the success or failure of creation process.</returns>
    Task<DemoAtomDTO> AddDemoAtomAsync(CreateDemoAtomDTO demoAtomDto);

    Task<DemoAtomDTO?> GetDemoAtomByIdAsync(string id);
    Task<List<DemoAtomDTO>> GetAllDemoAtomsAsync();
    Task<DemoAtomDTO?> UpdateDemoAtomAsync(string id, DemoAtomDTO demoAtomDto);
    Task<bool> DeleteDemoAtomAsync(string id);
}