using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[Table("Service")]
public partial class Service
{
    [Key]
    public int ServiceId { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    [InverseProperty("Service")]
    public virtual ICollection<ServiceOption> ServiceOptions { get; set; } = new List<ServiceOption>();
}
