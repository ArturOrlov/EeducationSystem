using EducationSystem.Entities.DbModels;
using EducationSystem.Entities.DbModels.Dictionaries;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Entities.DbModels.Material.LaboratoryWork;
using EducationSystem.Entities.DbModels.Material.Lecture;
using EducationSystem.Entities.DbModels.Material.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Context;

public class EducationSystemDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole,
    IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public EducationSystemDbContext(DbContextOptions<EducationSystemDbContext> options, IConfiguration configRoot) :
        base(options)
    {
        _configRoot = (IConfigurationRoot)configRoot;
    }

    private readonly IConfigurationRoot _configRoot;

    private const string IdentitySchema = "Identity";
    private const string EducationSchema = "Education";
    private const string MaterialSchema = "Material";

    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<RoleClaim> UserClaim { get; set; }
    public DbSet<RoleClaim> RoleClaim { get; set; }
    public DbSet<UserInfo> UserInfo { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<Device> Device { get; set; }
    public DbSet<RefreshToken> RefreshToken { get; set; }
    public DbSet<VerificationToken> VerificationToken { get; set; }
    public DbSet<ApplicationSettings> ApplicationSettings { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<LaboratoryWork> LaboratoryWork { get; set; }
    public DbSet<UserLaboratoryWork> UserLaboratoryWork { get; set; }
    public DbSet<Lecture> Lecture { get; set; }
    public DbSet<UserLecture> UserLecture { get; set; }
    public DbSet<Test> Test { get; set; }
    public DbSet<TestAnswer> TestAnswer { get; set; }
    public DbSet<TestQuestion> TestQuestion { get; set; }
    public DbSet<UserTestResult> UserTestResult { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(entity =>
        {
            entity.ToTable("User", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<Role>(entity =>
        {
            entity.ToTable("Role", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<RoleClaim>(entity =>
        {
            entity.ToTable("RoleClaim", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<UserClaim>(entity =>
        {
            entity.ToTable("UserClaim", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<UserInfo>(entity =>
        {
            entity.ToTable("UserInfo", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<Device>(entity =>
        {
            entity.ToTable("Device", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("RefreshToken", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<VerificationToken>(entity =>
        {
            entity.ToTable("VerificationToken", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<ApplicationSettings>(entity =>
        {
            entity.ToTable("ApplicationSettings", IdentitySchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<Course>(entity =>
        {
            entity.ToTable("Course", EducationSchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<Subject>(entity =>
        {
            entity.ToTable("Subject", EducationSchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<LaboratoryWork>(entity =>
        {
            entity.ToTable("LaboratoryWork", MaterialSchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<UserLaboratoryWork>(entity =>
        {
            entity.ToTable("UserLaboratoryWork", MaterialSchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<Lecture>(entity =>
        {
            entity.ToTable("Lecture", MaterialSchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<UserLecture>(entity =>
        {
            entity.ToTable("UserLecture", MaterialSchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<Test>(entity =>
        {
            entity.ToTable("Test", MaterialSchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<TestAnswer>(entity =>
        {
            entity.ToTable("TestAnswer", MaterialSchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<TestQuestion>(entity =>
        {
            entity.ToTable("TestQuestion", MaterialSchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });

        builder.Entity<UserTestResult>(entity =>
        {
            entity.ToTable("UserTestResult", MaterialSchema);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configRoot.GetConnectionString("DefaultConnection"));
    }
}