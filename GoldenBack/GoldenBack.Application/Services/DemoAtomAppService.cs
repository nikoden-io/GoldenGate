// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Nikoden.IO All rights reserved.
//     Author: Nicolas Denoël
// </copyright>
// -----------------------------------------------------------------------

using Application.DTO.ApplicationDTO;
using Application.Interfaces.ApplicationServices;
using AutoMapper;
using Domain.Entities;
using GoldenBack.Domain.IRepositories;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace Application.Services.AppServices;

public class DemoAtomAppService : IDemoAtomAppService
{
    private readonly IDemoAtomRepository _demoAtomRepository;
    private readonly ILogger<DemoAtomAppService> _logger;
    private readonly IMapper _mapper;

    public DemoAtomAppService(IDemoAtomRepository demoAtomRepository, IMapper mapper,
        ILogger<DemoAtomAppService> logger)
    {
        _demoAtomRepository = demoAtomRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DemoAtomDTO> AddDemoAtomAsync(CreateDemoAtomDTO demoAtomDto)
    {
        var demoAtom = new DemoAtom
        {
            Id = ObjectId.GenerateNewId().ToString(),
            DemoFieldOne = demoAtomDto.DemoFieldOne,
            IsDemo = demoAtomDto.IsDemo
        };
        await _demoAtomRepository.AddDemoAtomAsync(demoAtom);
        return _mapper.Map<DemoAtomDTO>(demoAtom);
    }

    public async Task<DemoAtomDTO?> GetDemoAtomByIdAsync(string id)
    {
        var demoAtom = await _demoAtomRepository.GetDemoAtomByIdAsync(id);
        return demoAtom != null ? _mapper.Map<DemoAtomDTO>(demoAtom) : null;
    }

    public async Task<List<DemoAtomDTO>> GetAllDemoAtomsAsync()
    {
        var demoAtoms = await _demoAtomRepository.GetAllDemoAtomsAsync();
        return _mapper.Map<List<DemoAtomDTO>>(demoAtoms);
    }

    public async Task<DemoAtomDTO?> UpdateDemoAtomAsync(string id, DemoAtomDTO demoAtomDto)
    {
        var existingDemoAtom = await _demoAtomRepository.GetDemoAtomByIdAsync(id);
        if (existingDemoAtom == null)
            return null;

        existingDemoAtom.DemoFieldOne = demoAtomDto.DemoFieldOne;
        existingDemoAtom.IsDemo = demoAtomDto.IsDemo;

        await _demoAtomRepository.UpdateDemoAtomAsync(existingDemoAtom);
        return _mapper.Map<DemoAtomDTO>(existingDemoAtom);
    }

    public async Task<bool> DeleteDemoAtomAsync(string id)
    {
        return await _demoAtomRepository.DeleteDemoAtomAsync(id);
    }
}