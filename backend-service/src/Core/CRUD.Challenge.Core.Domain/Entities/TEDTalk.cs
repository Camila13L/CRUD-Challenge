using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Challenge.Core.Domain.Entities;

public class TEDTalk
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TEDTalkId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime DateOfEvent { get; set; }
    public string Speaker { get; set; } = string.Empty;
    public string auditoriumName { get; set; } = string.Empty;
    public int CityId { get; set; }

    [ForeignKey("CityId")]
    public virtual City? City { get; set; }
}

