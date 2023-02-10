using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RobotsManagement.Data.Repository.Models;

[Table("Robot")]
public partial class Robot
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    public int? UserId { get; set; }

    public int? RobotTypeId { get; set; }

    [ForeignKey("RobotTypeId")]
    [InverseProperty("Robots")]
    public virtual RobotType? RobotType { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Robots")]
    public virtual User? User { get; set; }
}
