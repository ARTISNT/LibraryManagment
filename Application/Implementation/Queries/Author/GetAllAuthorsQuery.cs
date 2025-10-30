using Application.Dto.AuthorsDto;
using MediatR;

namespace Application.Implementation.Queries.Author;

public record GetAllAuthorsQuery(AuthorFilteringDto AuthorFilteringDto) : IRequest<IEnumerable<AuthorResponseWithBookCountDto>>;