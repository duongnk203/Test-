using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[Table("Size")]
public partial class Size
{
    [Key]
    public int SizeId { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [InverseProperty("Size")]
    public virtual ICollection<ProductOption> ProductOptions { get; set; } = new List<ProductOption>();
}
