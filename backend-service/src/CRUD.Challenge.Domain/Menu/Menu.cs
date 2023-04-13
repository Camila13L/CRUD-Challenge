using System;
using CRUD.Challenge.Domain.Common.Models;
using CRUD.Challenge.Domain.Menu.Entities;
using CRUD.Challenge.Domain.Menu.ValueObjects;

namespace CRUD.Challenge.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();

    public string Name { get; }

    public string Description { get; }

    public float AverageRating { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public Menu(MenuId menuId, string name, string description, float avergeRating) : base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating = avergeRating;
    }

    public static Menu Create(string name, string description, float avergeRating)
    {
        return new(MenuId.CreateUnique(), name, description, avergeRating);
    }
}

