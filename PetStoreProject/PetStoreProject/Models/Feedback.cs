using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

[PrimaryKey("FeedbackId", "CustomerId", "ProductId")]
[Table("Feedback")]
public partial class Feedback
{
    [Key]
    public int FeedbackId { get; set; }

    [Key]
    public int CustomerId { get; set; }

    [Key]
    public int ProductId { get; set; }

    public int Rating { get; set; }

    [StringLength(500)]
    public string? Content { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }
}
