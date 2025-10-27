using Application.Dto.AuthorsDto;
using MediatR;

namespace Application.Implementation.Queries.Author;

public record GetAuthorByIdQuery(int Id) : IRequest<AuthorResponseDto>;