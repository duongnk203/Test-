using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[Table("Attribute")]
public partial class Attribute
{
    [Key]
    public int AttributeId { get; set; }

    [StringLength(10)]
    public string? Type { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    [InverseProperty("Attribute")]
    public virtual ICollection<ProductOption> ProductOptions { get; set; } = new List<ProductOption>();
}
