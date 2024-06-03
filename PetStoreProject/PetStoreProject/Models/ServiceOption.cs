using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[PrimaryKey("ServiceId", "PetType")]
[Table("ServiceOption")]
public partial class ServiceOption
{
    [Key]
    public int ServiceId { get; set; }

    [Key]
    [StringLength(50)]
    public string PetType { get; set; } = null!;

    public float Price { get; set; }

    [ForeignKey("ServiceId")]
    [InverseProperty("ServiceOptions")]
    public virtual Service Service { get; set; } = null!;
}
