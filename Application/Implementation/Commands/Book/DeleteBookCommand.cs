using MediatR;

namespace Application.Implementation.Commands.Book;

public record DeleteBookCommand(int Id) : IRequest;