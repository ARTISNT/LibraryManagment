using Application.Dto.AuthorsDto;
using Domain.Models.Entities;

namespace Application.Abstractions.Repositories;

public interface IAuthorRepository
{
    public Task<IEnumerable<AuthorEntity>> GetAll(AuthorFilteringDto  authorFilteringDto);
    public Task<AuthorEntity> GetById(int id);
    public Task Create(AuthorEntity entity);
    public Task Update(int id, AuthorEntity entity);
    public Task Delete(int id);
}