using System;
using CRUD.Challenge.Core.Domain.Common;

namespace CRUD.Challenge.Core.Domain.Entities;

public class TEDTalk : AuditableBaseEntity
{
    public string Title { get; set; } = string.Empty;
    public DateTime DateOfEvent { get; set; }
    public string Speaker { get; set; } = string.Empty;
    public string auditoriumName { get; set; } = string.Empty;

    public City City { get; set; } = new City();
}

