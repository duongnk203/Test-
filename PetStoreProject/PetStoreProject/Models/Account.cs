using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[Table("Account")]
public partial class Account
{
    [Key]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string Password { get; set; } = null!;

    [InverseProperty("EmailNavigation")]
    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    [InverseProperty("EmailNavigation")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("EmailNavigation")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [ForeignKey("Email")]
    [InverseProperty("Emails")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
