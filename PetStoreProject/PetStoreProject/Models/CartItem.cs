using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[Table("CartItem")]
public partial class CartItem
{
    [Key]
    public int CartItemId { get; set; }

    public int ProductOptionId { get; set; }

    public int Quantity { get; set; }

    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("CartItems")]
    public virtual Customer Customer { get; set; } = null!;
}
