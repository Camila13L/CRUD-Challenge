using System;
using CRUD.Challenge.Domain.Common.Models;
using CRUD.Challenge.Domain.Menu.ValueObjects;

namespace CRUD.Challenge.Domain.Host.ObjectValues;

public class HostId : ValueObject
{
    public Guid Value { get; set; }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

