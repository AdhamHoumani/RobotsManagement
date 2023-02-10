using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RobotsManagement.Data.Repository.Models;

[Table("User")]
public partial class User
{
    [Key]
    public int Id { get; set; }

    public Guid? UserSystemId { get; set; }

    [StringLength(30)]
    public string? FirstName { get; set; }

    [StringLength(30)]
    public string? LastName { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    public string? Password { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AddedDate { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Robot> Robots { get; } = new List<Robot>();
}
