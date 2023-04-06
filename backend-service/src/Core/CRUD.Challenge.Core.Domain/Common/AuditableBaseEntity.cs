using System;
namespace CRUD.Challenge.Core.Domain.Common;

public abstract class AuditableBaseEntity
{
	public virtual  int Id { get; set; }
	public string CreatedBy { get; set; }
	public DateTime CreationDate { get; set; }
	public string LastModifiedBy { get; set; }
	public DateTime? LastModifiedDate { get; set; }

}

