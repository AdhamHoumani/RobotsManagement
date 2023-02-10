using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RobotsManagement.Data.Repository.Models;

[Table("TypeModel")]
public partial class TypeModel
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    public string? Name { get; set; }

    [StringLength(50)]
    public string? Description { get; set; }

    [InverseProperty("Model")]
    public virtual ICollection<RobotType> RobotTypes { get; } = new List<RobotType>();
}
