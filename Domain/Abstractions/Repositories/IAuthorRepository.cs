using Domain.Models.Entities;

namespace Domain.Abstractions.Repositories;

public interface IAuthorRepository
{
    public IQueryable<AuthorEntity> GetAll();
    public Task<AuthorEntity> GetById(int id);
    public Task Create(AuthorEntity entity);
    public Task Update(int id, AuthorEntity entity);
    public Task Delete(int id);
}