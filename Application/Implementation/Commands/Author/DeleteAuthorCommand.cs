using MediatR;

namespace Application.Implementation.Commands.Author;

public record DeleteAuthorCommand(int Id) : IRequest;