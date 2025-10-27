using Application.Dto.BookDto;
using MediatR;

namespace Application.Implementation.Commands.Book;

public record CreateBookCommand(CreateBookDto BookDto) : IRequest<int>;