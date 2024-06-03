using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[PrimaryKey("ProductId", "CustomerId")]
[Table("FavouriteList")]
public partial class FavouriteList
{
    [Key]
    public int ProductId { get; set; }

    [Key]
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("FavouriteLists")]
    public virtual Customer Customer { get; set; } = null!;
}
