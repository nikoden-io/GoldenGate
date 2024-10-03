// -----------------------------------------------------------------------
// <copyright>
//     Copyright 2024, Nikoden.IO All rights reserved.
//     Author: Nicolas Denoël
// </copyright>
// -----------------------------------------------------------------------

using Domain.Entities;
using MongoDB.Bson;

namespace GoldenBack.Tests.Builders;

public class DemoAtomBuilder
{
    private readonly DemoAtom _demoAtom;

    public DemoAtomBuilder()
    {
        _demoAtom = new DemoAtom
        {
            Id = ObjectId.GenerateNewId().ToString(),
            DemoFieldOne = "Default field",
            IsDemo = false
        };
    }

    public DemoAtomBuilder WithId(string id)
    {
        _demoAtom.Id = id;
        return this;
    }

    public DemoAtomBuilder WithDemoFieldOne(string demoFieldOne)
    {
        _demoAtom.DemoFieldOne = demoFieldOne;
        return this;
    }

    public DemoAtomBuilder WithIsDemo(bool isDemo)
    {
        _demoAtom.IsDemo = isDemo;
        return this;
    }

    public DemoAtom Build()
    {
        return _demoAtom;
    }
}