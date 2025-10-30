using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using Infrastructure.DB;
using Infrastructure.DB.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private LibraryManagementDbContext  _libraryManagementDbContext;
    public AuthorRepository(LibraryManagementDbContext libraryManagementDbContext)
    {
        _libraryManagementDbContext = libraryManagementDbContext;
    }

    public IQueryable<AuthorEntity> GetAll()
    {
        return _libraryManagementDbContext.Authors.AsQueryable();
    }

    public async Task<AuthorEntity?> GetById(int id)
    {
        var author = await _libraryManagementDbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        CheckForNull(author);
            
        return author;
    }

    public async Task Create(AuthorEntity entity)
    {
        await _libraryManagementDbContext.Authors.AddAsync(entity);
        await _libraryManagementDbContext.SaveChangesAsync();
    }

    public async Task Update(int id, AuthorEntity entity)
    {
        var author = await _libraryManagementDbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        CheckForNull(entity);
        
        author.Name = entity.Name;
        author.DateOfBirthday =  entity.DateOfBirthday;
        
        await _libraryManagementDbContext.SaveChangesAsync();
    }
    
    public async Task Delete(int id)
    {
        var author = await _libraryManagementDbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        CheckForNull(author);
        
        _libraryManagementDbContext.Authors.Remove(author);
        await _libraryManagementDbContext.SaveChangesAsync();
    }

    private void CheckForNull(AuthorEntity entity)
    {
       if (entity == null)
           throw new NullReferenceException("Author not found");
    }
}