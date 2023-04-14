using System;
using CRUD.Challenge.Domain.Common.Models;
using CRUD.Challenge.Domain.Menu.ValueObjects;

namespace CRUD.Challenge.Domain.Dinner.ObjectValues;

public class DinnerId : ValueObject
{
    public Guid Value { get; set; }

    private DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

