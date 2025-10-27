using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using Infrastructure.DB;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    
    private IListDb _db;

    public BookRepository(IListDb db)
    {
        _db = db;
    }

    public async Task<IReadOnlyCollection<BookEntity>> GetAll()
    {
        await Task.Delay(400);
        return _db.Books;
    }

    public async Task<BookEntity?> GetById(int id)
    {
        await Task.Delay(400);
        return _db.Books.FirstOrDefault(x => x.Id == id);
    }

    public async Task<BookEntity> Create(BookEntity entity)
    {
        await Task.Delay(400);
        var books = _db.Books as List<BookEntity>;
        
        entity.Id = books.Max(a => a.Id) + 1;
        books.Add(entity);
        
        return entity;
    }

    public async Task<BookEntity> Update(int id, BookEntity entity)
    {
        await Task.Delay(400);
        var books = _db.Books as List<BookEntity>;
        
        var updatedBook = books.FirstOrDefault(b => b.Id == id);
        
        updatedBook.Title = entity.Title;
        updatedBook.PublishYear = entity.PublishYear;
        
        return updatedBook;
    }

    public async Task Delete(int id)
    {
        await Task.Delay(400);
        
        var books = _db.Books as List<BookEntity>;
        books.Remove(books.FirstOrDefault(a => a.Id == id));
    }
}