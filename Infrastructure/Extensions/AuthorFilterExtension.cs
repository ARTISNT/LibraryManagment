using Application.Dto.AuthorsDto;
using Domain.Models.Entities;

namespace Infrastructure.Extensions;

public static class AuthorFilterExtension
{
    public static IQueryable<AuthorEntity> ApplyFiltering(
        this IQueryable<AuthorEntity> query, AuthorFilteringDto authorFilteringDto)
    {
        
        if (!string.IsNullOrWhiteSpace(authorFilteringDto.Name))
            query = query.Where(a => a.Name.Contains(authorFilteringDto.Name));

        if (authorFilteringDto.CountOfBooks.HasValue)
        {
            query = query.Where(a => a.Books.Count == authorFilteringDto.CountOfBooks.Value);
        }

        return query;
    }
}