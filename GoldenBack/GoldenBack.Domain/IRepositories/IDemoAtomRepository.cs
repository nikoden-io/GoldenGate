// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Nikoden.IO All rights reserved.
//     Author: Nicolas Denoël
// </copyright>
// -----------------------------------------------------------------------

using Domain.Entities;

namespace GoldenBack.Domain.IRepositories;

/// <summary>
///     Interface that drives implementation of database repository to manage demoAtom.
/// </summary>
public interface IDemoAtomRepository
{
    /// <summary>
    ///     Add a demoAtom to the database
    /// </summary>
    /// <param name="demoAtom">Build DemoAtom entity to save to database.</param>
    /// <returns>A task that returns creation success state.</returns>
    Task AddDemoAtomAsync(DemoAtom demoAtom);

    /// <summary>
    ///     Delete a demoAtom from the database
    /// </summary>
    /// <param name="demoAtomId">Unique DemoAtom identifier.</param>
    /// <returns>A task that returns delete success state.</returns>
    Task<bool> DeleteDemoAtomAsync(string demoAtomId);


    /// <summary>
    ///     Retrieves a demoAtom by its unique identifier.
    /// </summary>
    /// <param name="demoAtomId">The unique identifier of DemoAtom.</param>
    /// <returns>A task that returns found DemoAtom if it exists.</returns>
    Task<DemoAtom?> GetDemoAtomByIdAsync(string demoAtomId);

    /// <summary>
    ///     Retrieves all demoAtom entries.
    /// </summary>
    /// <returns>A task that returns found DemoAtom list.</returns>
    Task<List<DemoAtom>> GetAllDemoAtomsAsync();


    /// <summary>
    ///     Update a demoAtom in the database
    /// </summary>
    /// <param name="demoAtom">Build DemoAtom entity to update in database.</param>
    /// <returns>A task that returns update success state.</returns>
    Task UpdateDemoAtomAsync(DemoAtom demoAtom);
}