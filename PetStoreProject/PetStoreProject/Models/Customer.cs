using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[Table("Customer")]
public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(250)]
    public string FullName { get; set; } = null!;

    public bool Gender { get; set; }

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    public DateOnly DoB { get; set; }

    [StringLength(250)]
    public string Address { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    [ForeignKey("Email")]
    [InverseProperty("Customers")]
    public virtual Account EmailNavigation { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<FavouriteList> FavouriteLists { get; set; } = new List<FavouriteList>();
}
