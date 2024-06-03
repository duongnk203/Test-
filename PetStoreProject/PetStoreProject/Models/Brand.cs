using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[Table("Brand")]
public partial class Brand
{
    [Key]
    public int BrandId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;
}
