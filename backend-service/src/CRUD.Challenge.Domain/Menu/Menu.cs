using System;
using CRUD.Challenge.Domain.Common.Models;
using CRUD.Challenge.Domain.Dinner.ObjectValues;
using CRUD.Challenge.Domain.Host.ObjectValues;
using CRUD.Challenge.Domain.Menu.Entities;
using CRUD.Challenge.Domain.Menu.ValueObjects;

namespace CRUD.Challenge.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();

    public string Name { get; }

    public string Description { get; }

    public float AverageRating { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDatetime { get; }
    public DateTime UpdatedDateTime { get; }


    private Menu
        (
        MenuId menuId,
        string name,
        string description,
        float avergeRating,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime
        ) : base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating = avergeRating;
        HostId = hostId;
        CreatedDatetime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create
        (
        string name,
        string description,
        float avergeRating,
        HostId hostId
        )
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            avergeRating,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow
            );
    }
}

