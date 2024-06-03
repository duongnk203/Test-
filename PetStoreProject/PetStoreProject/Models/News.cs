using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

public partial class News
{
    [Key]
    public int NewsId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateOnly DatePosted { get; set; }

    public int EmployeeId { get; set; }
}
