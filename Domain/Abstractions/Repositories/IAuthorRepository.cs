using Domain.Models.Entities;

namespace Domain.Abstractions.Repositories;

public interface IAuthorRepository
{
    public Task<IReadOnlyCollection<AuthorEntity>> GetAll();
    public Task<AuthorEntity> GetById(int id);
    public Task<AuthorEntity> Create(AuthorEntity entity);
    public Task<AuthorEntity> Update(int id, AuthorEntity entity);
    public Task Delete(int id);
}