using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Resources;
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
    public DbSet<Language> Languages { get; set; }
    
    public DbSet<Saga> Sagas { get; set; }
    
    public DbSet<SagaStatus> SagaStatuses { get; set; }
    
    public DbSet<Book> Books { get; set; }
    
    public DbSet<BookStatus> BookStatuses { get; set; }
    public DbSet<Chapters> Chapters { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Users
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

        //User Profile
        modelBuilder.Entity<UserProfile>().ToTable("user_profile");
        modelBuilder.Entity<UserProfile>().HasKey(p => p.Id);
        modelBuilder.Entity<UserProfile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<UserProfile>().Property(p => p.Name).IsRequired().HasMaxLength(30);

        //Genres
        modelBuilder.Entity<Genre>().ToTable("Genres");
        modelBuilder.Entity<Genre>().HasKey(p => p.Id);
        modelBuilder.Entity<Genre>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Genre>().Property(p => p.Name).IsRequired().HasMaxLength(24);
        modelBuilder.Entity<Genre>()
            .HasMany(s => s.BookGenres)
            .WithOne(b => b.Genre)
            .HasForeignKey(p => p.GenreId);
        
        //Chapters
        modelBuilder.Entity<Chapters>().ToTable("Chapters");
        modelBuilder.Entity<Chapters>().HasKey(s => s.Id);
        modelBuilder.Entity<Chapters>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Chapters>().Property(s => s.Title).IsRequired().HasMaxLength(24);
        modelBuilder.Entity<Chapters>().Property(s => s.Document_content_url).IsRequired().HasMaxLength(50);
       
        //Languages
        modelBuilder.Entity<Language>().ToTable("Languages");
        modelBuilder.Entity<Language>().HasKey(p => p.Id);
        modelBuilder.Entity<Language>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Language>().Property(p => p.Name).IsRequired().HasMaxLength(12);
        modelBuilder.Entity<Language>().Property(p => p.Abbreviation).IsRequired().HasMaxLength(4);
        modelBuilder.Entity<Language>()
            .HasMany(s=>s.Books)
            .WithOne(b => b.Language)
            .HasForeignKey(b => b.LanguageId);
        
        //Sagas
        modelBuilder.Entity<Saga>().ToTable("Sagas"); 
        modelBuilder.Entity<Saga>().HasKey(s => s.Id);
        modelBuilder.Entity<Saga>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Saga>().Property(s => s.Title).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Saga>().Property(s => s.Synopsis).IsRequired().HasMaxLength(500);
        modelBuilder.Entity<Saga>()
            .HasMany(s=>s.Books)
            .WithOne(b => b.Saga)
            .HasForeignKey(b => b.SagaId);

        
        //Saga Statuses
        modelBuilder.Entity<SagaStatus>().ToTable("SagaStatuses");
        modelBuilder.Entity<SagaStatus>().HasKey(ss => ss.Id);
        modelBuilder.Entity<SagaStatus>().Property(ss => ss.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<SagaStatus>().Property(ss => ss.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<SagaStatus>()
            .HasMany(ss=>ss.Sagas)
            .WithOne(s => s.SagaStatus)
            .HasForeignKey(s => s.SagaStatusId);
        
        //Books
        modelBuilder.Entity<Book>().ToTable("Books"); 
        modelBuilder.Entity<Book>().HasKey(s => s.Id);
        modelBuilder.Entity<Book>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Book>().Property(s => s.Title).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Book>().Property(s => s.Synopsis).IsRequired().HasMaxLength(500);
        modelBuilder.Entity<Book>().Property(s => s.PublishedAt).IsRequired();
        modelBuilder.Entity<Book>().Property(s => s.ThumbnailUrl).IsRequired();
        modelBuilder.Entity<Book>().Property(s => s.ProfileId).IsRequired();
        modelBuilder.Entity<Book>()
            .HasMany(s => s.Chapters)
            .WithOne(s => s.Book)
            .HasForeignKey(s => s.BookId);
        modelBuilder.Entity<Book>()
            .HasMany(s => s.BookGenres)
            .WithOne(s => s.Book)
            .HasForeignKey(s => s.BookId);
        
        
        //Book Statuses
        modelBuilder.Entity<BookStatus>().ToTable("BookStatuses");
        modelBuilder.Entity<BookStatus>().HasKey(ss => ss.Id);
        modelBuilder.Entity<BookStatus>().Property(ss => ss.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<BookStatus>().Property(ss => ss.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<BookStatus>()
            .HasMany(ss=>ss.Books)
            .WithOne(s => s.BookStatus)
            .HasForeignKey(s => s.BookStatusId);
        
        
        //Book-Genres
        modelBuilder.Entity<BookGenre>().ToTable("BookGenres");
        modelBuilder.Entity<BookGenre>().HasKey(s => s.Id);
        modelBuilder.Entity<BookGenre>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<BookGenre>()
            .HasOne(s => s.Book)
            .WithMany(s => s.BookGenres)
            .HasForeignKey(s => s.BookId);
        modelBuilder.Entity<BookGenre>()
            .HasOne(s => s.Genre)
            .WithMany(s => s.BookGenres)
            .HasForeignKey(s => s.GenreId);
        
        modelBuilder.UseSnakeCaseNamingConvention();
    }
}