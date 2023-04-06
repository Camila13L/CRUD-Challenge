namespace CRUD.Challenge.Core.Domain.Entities;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class City
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CityId { get; set; }
	public string Name { get; set; } = string.Empty;

	public ICollection<TEDTalk>? TEDTalks { get; }
}

