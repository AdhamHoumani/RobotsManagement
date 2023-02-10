using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RobotsManagement.Data.Repository.Models;

[Table("RobotType")]
public partial class RobotType
{
    [Key]
    public int Id { get; set; }

    public int? ModelId { get; set; }

    [StringLength(25)]
    public string? Name { get; set; }

    [StringLength(50)]
    public string? Description { get; set; }

    [ForeignKey("ModelId")]
    [InverseProperty("RobotTypes")]
    public virtual TypeModel? Model { get; set; }

    [InverseProperty("RobotType")]
    public virtual ICollection<Robot> Robots { get; } = new List<Robot>();
}
