using EducationSystem.Entities.DbModels.Dictionaries;
using EducationSystem.Entities.DbModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Context;

public class EducationSystemDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public EducationSystemDbContext(DbContextOptions<EducationSystemDbContext> options, IConfiguration configRoot) : base(options)
    {
        ConfigRoot = (IConfigurationRoot)configRoot;
    }
    
    private IConfigurationRoot ConfigRoot;

    private const string IdentitySchema = "Identity";
    private const string EducationSchema = "Education";

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
    // public DbSet<Course> Courses { get; set; }
    // public DbSet<CourseStatus> CourseStatus { get; set; }
    // public DbSet<Material> Materials { get; set; }
    // public DbSet<Performance> Performances { get; set; }
    // public DbSet<Subject> Subjects { get; set; }

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

        // builder.Entity<Course>(entity =>
        // {
        //     entity.ToTable("Course", EducationSchema);
        //     entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        //     entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        // });
        //
        // builder.Entity<CourseStatus>(entity =>
        // {
        //     entity.ToTable("CourseStatus", EducationSchema);
        //     entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        //     entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        // });
        //
        // builder.Entity<Material>(entity =>
        // {
        //     entity.ToTable("Material", EducationSchema);
        //     entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        //     entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        // });
        //
        // builder.Entity<Performance>(entity =>
        // {
        //     entity.ToTable("Performance", EducationSchema);
        //     entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        //     entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        // });
        //
        // builder.Entity<Subject>(entity =>
        // {
        //     entity.ToTable("Subject", EducationSchema);
        //     entity.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        //     entity.Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        // });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConfigRoot.GetConnectionString("DefaultConnection"));
    }
}