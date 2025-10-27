using Application.Dto.AuthorsDto;
using MediatR;

namespace Application.Implementation.Commands.Author;

public record UpdateAuthorCommand(int Id, UpdateAuthorDto AuthorDto) : IRequest<int>;