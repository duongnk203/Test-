using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[Table("ProductOption")]
public partial class ProductOption
{
    [Key]
    public int ProductOptionId { get; set; }

    public int ProductId { get; set; }

    public int? SizeId { get; set; }

    public int? AttributeId { get; set; }

    public float Price { get; set; }

    public int ImageId { get; set; }

    [ForeignKey("AttributeId")]
    [InverseProperty("ProductOptions")]
    public virtual Attribute? Attribute { get; set; }

    [ForeignKey("ImageId")]
    [InverseProperty("ProductOptions")]
    public virtual Image Image { get; set; } = null!;

    [ForeignKey("SizeId")]
    [InverseProperty("ProductOptions")]
    public virtual Size? Size { get; set; }
}
