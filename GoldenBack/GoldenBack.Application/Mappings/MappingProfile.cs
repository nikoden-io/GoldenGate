// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Nikoden.IO All rights reserved.
//     Author: Nicolas Denoël
// </copyright>
// -----------------------------------------------------------------------

using Application.DTO.ApplicationDTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

/// <summary>
///     Defines the AutoMapper profile for mapping between domain entities and DTOs.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MappingProfile" /> class.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<CreateDemoAtomDTO, DemoAtomDTO>().ReverseMap();
        CreateMap<DemoAtom, DemoAtomDTO>();
    }
}