using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.Shared.Extensions;
using ReadOwoBackend.ReadOwo.Domain.Models;

namespace ReadOwoBackend.ReadOwo.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(p => p.Id);
        modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<User>().Property(p => p.email).IsRequired().HasMaxLength(240);
        modelBuilder.Entity<User>().Property(p => p.password).IsRequired().HasMaxLength(240);
        
        
        modelBuilder.UseSnakeCaseNamingConvention();
    }
}