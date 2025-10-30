using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using Infrastructure.DB;
using Infrastructure.DB.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    
    private LibraryManagementDbContext _libraryManagementDbContext;
    public BookRepository(LibraryManagementDbContext libraryManagementDbContext)
    {
        _libraryManagementDbContext = libraryManagementDbContext;
    }

    public IQueryable<BookEntity> GetAll()
    {
        return _libraryManagementDbContext.Books;
    }

    public async Task<BookEntity?> GetById(int id)
    {
        var book = await _libraryManagementDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        CheckForNull(book);
        
        return book;
    }

    public async Task Create(BookEntity entity)
    {
        await _libraryManagementDbContext.Books.AddAsync(entity);
        await _libraryManagementDbContext.SaveChangesAsync();
    }

    public async Task Update(int id, BookEntity entity)
    {
        var book = await _libraryManagementDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        CheckForNull(book);
        
        book.Title = entity.Title;
        book.PublishYear = entity.PublishYear;
        book.AuthorId = entity.AuthorId;
        
        await _libraryManagementDbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var book = await _libraryManagementDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        CheckForNull(book);
        
        _libraryManagementDbContext.Books.Remove(book);
        await _libraryManagementDbContext.SaveChangesAsync();
    }

    private void CheckForNull(BookEntity entity)
    {
        if (entity == null)
            throw new NullReferenceException($"Book not found");
    }
}