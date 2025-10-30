using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB.Context;

public class LibraryManagementDbContext : DbContext
{
    public LibraryManagementDbContext(DbContextOptions<LibraryManagementDbContext> options) : base(options) { }
    
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AuthorEntity>().HasData(
            new AuthorEntity { Id = 1, Name = "John Doe",  DateOfBirthday = new DateTime(1980, 1, 1) },
            new AuthorEntity { Id = 2, Name = "Bob Jones", DateOfBirthday = new DateTime(1980, 2, 1) }
        );

        modelBuilder.Entity<BookEntity>().HasData(
            new BookEntity { Id = 1, Title = "Borovik", AuthorId = 1, PublishYear = 2000},
            new BookEntity { Id = 3, Title = "Wolk auf", AuthorId = 1, PublishYear = 2003},
            new BookEntity { Id = 2, Title = "Crazy frog", AuthorId = 2, PublishYear = 2002}
        );
    }
}