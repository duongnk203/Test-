using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[Table("Product")]
public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    public int BrandId { get; set; }

    public int ProductCateId { get; set; }

    public string? Description { get; set; }
}
