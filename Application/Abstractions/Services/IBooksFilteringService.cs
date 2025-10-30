using Application.Dto.BookDto;

namespace Application.Abstractions.Services;

public interface IBooksFilteringService
{
    public Task<IEnumerable<BookDtoResponse>> ApplyFiltering(BookFilteringDto bookFilteringDto);
}