using Application.Dto.AuthorsDto;
using Application.Dto.BookDto;
using Domain.Models.Entities;

namespace Infrastructure.Extensions;

public static class BookFilterExtension
{
    public static IQueryable<BookEntity> ApplyFiltering(
        this IQueryable<BookEntity> query, BookFilteringDto bookFilteringDto)
    {
        if (bookFilteringDto.PublishingYear.HasValue)
            query = query.Where(b => b.PublishYear >= bookFilteringDto.PublishingYear);
        
        return query;
    }
}