using Application.Dto.AuthorsDto;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Queries.Author;

public record GetAllAuthorsQuery(AuthorFilteringDto AuthorFilteringDto) : IRequest<IEnumerable<AuthorResponseDto>>;