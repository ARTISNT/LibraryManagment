using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using Infrastructure.DB;

namespace Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private IListDb _db;

    public AuthorRepository(IListDb db)
    {
        _db = db;
    }

    public async Task<IReadOnlyCollection<AuthorEntity>> GetAll()
    {
        await Task.Delay(400);
        return _db.Authors;
    }

    public async Task<AuthorEntity?> GetById(int id)
    {
        await Task.Delay(400);
        return _db.Authors.FirstOrDefault(x => x.Id == id);
    }

    public async Task<AuthorEntity> Create(AuthorEntity entity)
    {
        await Task.Delay(400);
        var authors = _db.Authors as List<AuthorEntity>;
        
        entity.Id = authors.Max(a => a.Id) + 1;
        authors.Add(entity);
        
        return entity;
    }

    public async Task<AuthorEntity> Update(int id, AuthorEntity entity)
    {
        await Task.Delay(400);
        var authors = _db.Authors as List<AuthorEntity>;
        
        var updatedAuthor = authors.FirstOrDefault(a => a.Id == id);
        
        updatedAuthor.Name = entity.Name;
        updatedAuthor.DateOfBirthday = entity.DateOfBirthday;
        
        return updatedAuthor;
    }
    
    public async Task Delete(int id)
    {
        await Task.Delay(400);
        
        var authors = _db.Authors as List<AuthorEntity>;
        authors.Remove(authors.FirstOrDefault(a => a.Id == id));
    }
}