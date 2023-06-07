using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Shared.Extensions;
using ReadOwoBackend.ReadOwo.Domain.Models;

namespace ReadOwoBackend.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<UserProfile> User_profile { get; set; } 
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(p => p.Id);
        modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<User>().Property(p => p.email).IsRequired().HasMaxLength(240);
        modelBuilder.Entity<User>().Property(p => p.password).IsRequired().HasMaxLength(240);

        modelBuilder.Entity<User>()
            .HasMany(p => p.Profiles)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
        modelBuilder.Entity<UserProfile>().ToTable("user_profile");
        modelBuilder.Entity<UserProfile>().HasKey(p => p.Id);
        modelBuilder.Entity<UserProfile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<UserProfile>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        
        modelBuilder.Entity<Genre>().ToTable("Genres");
        modelBuilder.Entity<Genre>().HasKey(p=>p.Id);
        modelBuilder.Entity<Genre>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Genre>().Property(p=>p.Name).IsRequired().HasMaxLength(24);

        modelBuilder.UseSnakeCaseNamingConvention();
    }
}