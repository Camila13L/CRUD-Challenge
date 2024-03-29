﻿using System;
using CRUD.Challenge.Domain.Common.Models;

namespace CRUD.Challenge.Domain.Menu.ValueObjects;

public class MenuSectionId : ValueObject
{
    public Guid Value { get; set; }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

