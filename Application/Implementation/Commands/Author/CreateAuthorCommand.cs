using Application.Dto.AuthorsDto;
using MediatR;

namespace Application.Implementation.Commands.Author;

public record CreateAuthorCommand(CreateAuthorDto AuthorDto) : IRequest<int>;