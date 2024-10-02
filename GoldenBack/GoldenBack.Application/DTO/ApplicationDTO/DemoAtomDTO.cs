// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Nikoden.IO All rights reserved.
//     Author: Nicolas Denoël
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Application.DTO.ApplicationDTO;

public class DemoAtomDTO
{
    public string? Id { get; set; }

    [Required] public string DemoFieldOne { get; set; } = string.Empty;

    [Required] public bool IsDemo { get; set; }
}

public class DemoAtomsResponseDTO
{
    public List<DemoAtomDTO> DemoAtoms { get; set; }
}

public class DemoAtomResponseDTO
{
    public DemoAtomDTO DemoAtom { get; set; }
}

public class CreateDemoAtomDTO
{
    [Required] public string DemoFieldOne { get; set; } = string.Empty;

    [Required] public bool IsDemo { get; set; }
}