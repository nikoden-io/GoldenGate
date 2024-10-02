// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Domintell s.a. All rights reserved.
//     Author: Nicolas Denoël
//     Description: MongoDB repository implementation to manage demoAtoms.
// </copyright>
// -----------------------------------------------------------------------

using Domain.Entities;
using GoldenBack.Domain.IRepositories;
using GoldenBack.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace GoldenBack.Infrastructure.Repositories;

/// <summary>
///     Provides implementation for accessing and manipulating demoAtom data in the database.
/// </summary>
/// <summary>
///     Provides implementation for accessing and manipulating DemoAtom data in the database.
/// </summary>
public class DemoAtomRepository : IDemoAtomRepository
{
    private readonly ApplicationDbContext _context;

    public DemoAtomRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddDemoAtomAsync(DemoAtom demoAtom)
    {
        await _context.DemoAtoms.AddAsync(demoAtom);
        await _context.SaveChangesAsync();
    }

    public async Task<DemoAtom?> GetDemoAtomByIdAsync(string id)
    {
        return await _context.DemoAtoms.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<List<DemoAtom>> GetAllDemoAtomsAsync()
    {
        return await _context.DemoAtoms.ToListAsync();
    }

    public async Task UpdateDemoAtomAsync(DemoAtom demoAtom)
    {
        _context.DemoAtoms.Update(demoAtom);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteDemoAtomAsync(string demoAtomId)
    {
        var demoAtom = await _context.DemoAtoms.FirstOrDefaultAsync(d => d.Id == demoAtomId);
        if (demoAtom == null)
            return false;

        _context.DemoAtoms.Remove(demoAtom);
        await _context.SaveChangesAsync();
        return true;
    }
}