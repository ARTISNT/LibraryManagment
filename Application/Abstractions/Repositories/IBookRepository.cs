using Application.Dto.BookDto;
using Domain.Models.Entities;

namespace Application.Abstractions.Repositories;

public interface IBookRepository
{
    public Task<IEnumerable<BookEntity>> GetAll(BookFilteringDto bookFilteringDto);
    public Task<BookEntity> GetById(int id);
    public Task Create(BookEntity entity);
    public Task Update(int id, BookEntity entity);
    public Task Delete(int id);
}