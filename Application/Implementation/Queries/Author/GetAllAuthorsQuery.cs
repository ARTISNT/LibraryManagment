using Application.Dto.AuthorsDto;
using MediatR;

namespace Application.Implementation.Queries.Author;

public record GetAllAuthorsQuery() : IRequest<IEnumerable<AuthorResponseDto>>;