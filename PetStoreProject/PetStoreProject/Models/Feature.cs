using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[Table("Feature")]
public partial class Feature
{
    [Key]
    public int FeatureId { get; set; }

    [StringLength(100)]
    public string Url { get; set; } = null!;

    [ForeignKey("FeatureId")]
    [InverseProperty("Features")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
