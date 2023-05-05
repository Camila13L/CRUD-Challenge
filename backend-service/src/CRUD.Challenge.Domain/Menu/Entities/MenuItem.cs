﻿using System;
using CRUD.Challenge.Domain.Common.Models;
using CRUD.Challenge.Domain.Menu.ValueObjects;

namespace CRUD.Challenge.Domain.Menu.Entities;

public class MenuItem : Entity<MenuItemId>
{
    public string Name { get; }
    public string Description { get; }

    private MenuItem(MenuItemId menuItemId, string name, string description)
        : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

   public static MenuItem Create(string name, string description)
   {
        return new(MenuItemId.CreateUnique(), name, description);
   }
}
