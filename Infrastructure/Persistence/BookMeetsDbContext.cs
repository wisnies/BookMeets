using Domain.Common.Models;
using Domain.Entities.Author;
using Domain.Entities.Book;
using Domain.Entities.Genre;
using Domain.Entities.ManyToMany;
using Domain.Entities.User;
using Domain.Entities.UserRefreshToken;
using Domain.Entities.UserRole;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
  public class BookMeetsDbContext : DbContext
  {
    public BookMeetsDbContext(
      DbContextOptions<BookMeetsDbContext> options) : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      foreach (var entry in ChangeTracker.Entries<BaseEntity>())
      {
        entry.Entity.DateUpdated = DateTime.UtcNow;
        if (entry.State == EntityState.Added)
        {
          entry.Entity.DateCreated = DateTime.UtcNow;
        }
      }

      return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique();


      modelBuilder.Entity<BookAuthor>()
        .HasKey(ba => new { ba.BookId, ba.AuthorId });
      modelBuilder.Entity<BookAuthor>()
        .HasOne(b => b.Book).WithMany(ba => ba.Authors)
        .HasForeignKey(b => b.BookId);
      modelBuilder.Entity<BookAuthor>()
        .HasOne(b => b.Author).WithMany(ba => ba.Books)
        .HasForeignKey(a => a.AuthorId);

      modelBuilder.Entity<BookGenre>()
        .HasKey(bg => new { bg.BookId, bg.GenreId });
      modelBuilder.Entity<BookGenre>()
        .HasOne(b => b.Book).WithMany(bg => bg.Genres)
        .HasForeignKey(b => b.BookId);
      modelBuilder.Entity<BookGenre>()
        .HasOne(b => b.Genre).WithMany(bg => bg.Books)
        .HasForeignKey(g => g.GenreId);

      //base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }

  }
}
