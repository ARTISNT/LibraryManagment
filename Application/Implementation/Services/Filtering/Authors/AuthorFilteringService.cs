using Application.Abstractions.Services;
using Application.Dto.AuthorsDto;
using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementation.Services.Filtering.Authors;

public class AuthorFilteringService : IAuthorsFilteringService
{
    private readonly IAuthorRepository  _authorRepository;

    public AuthorFilteringService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<AuthorResponseWithBookCountDto>> ApplyFiltering(AuthorFilteringDto authorFilteringDto)
    {
        var query = _authorRepository.GetAll(); 

        if (!string.IsNullOrWhiteSpace(authorFilteringDto.Name))
            query = query.Where(a => a.Name.Contains(authorFilteringDto.Name));

        if (authorFilteringDto.GetCountOfBooks)
        {
            return await query
                .Select(a => new AuthorResponseWithBookCountDto
                {
                    BooksCount = a.Books.Count(),
                    Name = a.Name,
                    DateOfBirthday = a.DateOfBirthday,
                    Id = a.Id,
                })
                .ToListAsync();
        }

        return await query
            .Select(a => new AuthorResponseWithBookCountDto
            {
                Name = a.Name, 
                DateOfBirthday = a.DateOfBirthday,
                Id = a.Id,
                BooksCount = null
            })
            .ToListAsync();
    }
}