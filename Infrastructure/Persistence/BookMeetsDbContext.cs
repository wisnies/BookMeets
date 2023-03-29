using Domain.Common.Models;
using Domain.Entities.User;
using Domain.Entities.UserRefreshToken;
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

    public DbSet<User> Users { get; set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
  }
}
