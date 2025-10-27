using Application.Dto.BookDto;
using MediatR;

namespace Application.Implementation.Commands.Book;

public record UpdateBookCommand(int Id, UpdateBookDto BookDto) : IRequest<int>;