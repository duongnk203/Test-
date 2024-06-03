using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[Table("Employee")]
public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [StringLength(250)]
    public string FullName { get; set; } = null!;

    public bool Gender { get; set; }

    public DateOnly DoB { get; set; }

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [StringLength(250)]
    public string Address { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [ForeignKey("Email")]
    [InverseProperty("Employees")]
    public virtual Account EmailNavigation { get; set; } = null!;
}
