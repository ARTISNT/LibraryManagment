using Domain.Models.Entities;

namespace Domain.Abstractions.Repositories;

public interface IBookRepository
{
    public Task<IReadOnlyCollection<BookEntity>> GetAll();
    public Task<BookEntity> GetById(int id);
    public Task<BookEntity> Create(BookEntity entity);
    public Task<BookEntity> Update(int id, BookEntity entity);
    public Task Delete(int id);
}