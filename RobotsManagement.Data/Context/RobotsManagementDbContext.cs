using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RobotsManagement.Data.Repository.Models;

namespace RobotsManagement.Data.Context;

public partial class RobotsManagementDbContext : DbContext
{
    public RobotsManagementDbContext()
    {
    }

    public RobotsManagementDbContext(DbContextOptions<RobotsManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Robot> Robots { get; set; }

    public virtual DbSet<RobotType> RobotTypes { get; set; }

    public virtual DbSet<TypeModel> TypeModels { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Robot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Robot__3214EC07AAA4FA4C");

            entity.HasOne(d => d.RobotType).WithMany(p => p.Robots).HasConstraintName("FK__Robot__RobotType__5629CD9C");

            entity.HasOne(d => d.User).WithMany(p => p.Robots).HasConstraintName("FK__Robot__UserId__5535A963");
        });

        modelBuilder.Entity<RobotType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RobotTyp__3214EC0701C40150");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Model).WithMany(p => p.RobotTypes).HasConstraintName("FK__RobotType__Model__4F7CD00D");
        });

        modelBuilder.Entity<TypeModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TypeMode__3214EC07F4855200");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0728A1AFA9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
