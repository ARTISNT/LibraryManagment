using Application.Dto.AuthorsDto;

namespace Application.Abstractions.Services;

public interface IAuthorsFilteringService
{
    public Task<IEnumerable<AuthorResponseWithBookCountDto>> ApplyFiltering(AuthorFilteringDto authorFilteringDto);
}