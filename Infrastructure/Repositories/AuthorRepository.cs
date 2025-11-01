using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using Infrastructure.DB.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuthorRepository(LibraryManagementDbContext libraryManagementDbContext) : IAuthorRepository
{
    public IQueryable<AuthorEntity> GetAll()
    {
        return libraryManagementDbContext.Authors.AsQueryable();
    }

    public async Task<AuthorEntity?> GetById(int id)
    {
        var author = await libraryManagementDbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        CheckForNull(author);
            
        return author;
    }

    public async Task Create(AuthorEntity entity)
    {
        await libraryManagementDbContext.Authors.AddAsync(entity);
        await libraryManagementDbContext.SaveChangesAsync();
    }

    public async Task Update(int id, AuthorEntity entity)
    {
        var author = await libraryManagementDbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        CheckForNull(entity);
        
        author.Name = entity.Name;
        author.DateOfBirthday =  entity.DateOfBirthday;
        
        await libraryManagementDbContext.SaveChangesAsync();
    }
    
    public async Task Delete(int id)
    {
        var author = await libraryManagementDbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        CheckForNull(author);
        
        libraryManagementDbContext.Authors.Remove(author);
        await libraryManagementDbContext.SaveChangesAsync();
    }

    private void CheckForNull(AuthorEntity entity)
    {
       if (entity == null)
           throw new NullReferenceException("Author not found");
    }
}