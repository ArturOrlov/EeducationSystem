﻿using EducationSystem.Entities.DbModels;
using EducationSystem.Entities.DbModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Context;

public class EducationSystemDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public EducationSystemDbContext(DbContextOptions<EducationSystemDbContext> options) : base(options)
    {
    }

    private const string IdentitySchema = "Identity";
    private const string SchoolSchema = "School";

    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    
    // public DbSet<SchoolClass> Class { get; set; }
    // public DbSet<Homework> Homework { get; set; }
    // public DbSet<Subject> Subject { get; set; }
    // public DbSet<Timetable> Timetable { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User>(entity =>
        {
            entity.ToTable("User", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });
        
        builder.Entity<Role>(entity =>
        {
            entity.ToTable("Role", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });
        
        builder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });
        
        // builder.Entity<SchoolClass>(entity =>
        // {
        //     entity.ToTable("Class", SchoolSchema);
        //     entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        // });
        //
        // builder.Entity<Homework>(entity =>
        // {
        //     entity.ToTable("Homework", SchoolSchema);
        //     entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        // });
        //
        // builder.Entity<Subject>(entity =>
        // {
        //     entity.ToTable("Subject", SchoolSchema);
        //     entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        // });
        //
        // builder.Entity<Timetable>(entity =>
        // {
        //     entity.ToTable("Timetable", SchoolSchema);
        //     entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        // });
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ElectronicDiary;User Id=postgres;Password=Ferdinand514");
    }
}