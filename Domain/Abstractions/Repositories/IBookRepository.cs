using Domain.Models.Entities;

namespace Domain.Abstractions.Repositories;

public interface IBookRepository
{
    public IQueryable<BookEntity> GetAll();
    public Task<BookEntity> GetById(int id);
    public Task Create(BookEntity entity);
    public Task Update(int id, BookEntity entity);
    public Task Delete(int id);
}