using Application.Dto.BookDto;
using MediatR;

namespace Application.Implementation.Queries.Book;

public record GetAllBooksQuery(BookFilteringDto BookFilteringDto) : IRequest<IEnumerable<BookDtoResponse>>;