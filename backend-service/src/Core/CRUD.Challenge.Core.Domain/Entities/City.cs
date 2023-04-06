using System;
namespace CRUD.Challenge.Core.Domain.Entities;

public class City
{
	public int CityId { get; set; }
	public string Name { get; set; } = string.Empty;
	public ICollection<TEDTalk>? TEDTalks { get; }
}

