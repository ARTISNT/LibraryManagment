using Application.Abstractions.Repositories;
using Application.Dto.BookDto;
using Domain.Models.Entities;
using Infrastructure.DB.Context;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository(LibraryManagementDbContext libraryManagementDbContext) : IBookRepository
{
    public async Task<IEnumerable<BookEntity>> GetAll(BookFilteringDto bookFilteringDto)
    {
        return await libraryManagementDbContext
            .Books
            .ApplyFiltering(bookFilteringDto)
            .ToListAsync();
    }

    public async Task<BookEntity?> GetById(int id)
    {
        var book = await libraryManagementDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        CheckForNull(book);
        
        return book;
    }

    public async Task Create(BookEntity entity)
    {
        await libraryManagementDbContext.Books.AddAsync(entity);
        await libraryManagementDbContext.SaveChangesAsync();
    }

    public async Task Update(int id, BookEntity entity)
    {
        var book = await libraryManagementDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        CheckForNull(book);
        
        book.Title = entity.Title;
        book.PublishYear = entity.PublishYear;
        book.AuthorId = entity.AuthorId;
        
        await libraryManagementDbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var book = await libraryManagementDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        CheckForNull(book);
        
        libraryManagementDbContext.Books.Remove(book);
        await libraryManagementDbContext.SaveChangesAsync();
    }

    private void CheckForNull(BookEntity entity)
    {
        if (entity == null)
            throw new NullReferenceException($"Book not found");
    }
}