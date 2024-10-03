// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Nikoden.IO All rights reserved.
//     Author: Nicolas Denoël
// </copyright>
// -----------------------------------------------------------------------

using Application.DTO.ApplicationDTO;

namespace GoldenBack.Tests.Builders;

public class CreateDemoAtomDTOBuilder
{
    private readonly CreateDemoAtomDTO _createDemoAtomDto;

    public CreateDemoAtomDTOBuilder()
    {
        _createDemoAtomDto = new CreateDemoAtomDTO
        {
            DemoFieldOne = "Default field",
            IsDemo = false
        };
    }

    public CreateDemoAtomDTOBuilder WithDemoFieldOne(string demoFieldOne)
    {
        _createDemoAtomDto.DemoFieldOne = demoFieldOne;
        return this;
    }

    public CreateDemoAtomDTOBuilder WithIsDemo(bool isDemo)
    {
        _createDemoAtomDto.IsDemo = isDemo;
        return this;
    }

    public CreateDemoAtomDTO Build()
    {
        return _createDemoAtomDto;
    }
}