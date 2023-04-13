using System;
using CRUD.Challenge.Domain.Common.Models;

namespace CRUD.Challenge.Domain.Menu.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; set; }

    private MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

