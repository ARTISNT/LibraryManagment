using Application.Dto.BookDto;
using MediatR;

namespace Application.Implementation.Queries.Book;

public record GetAllBooksQuery() : IRequest<IEnumerable<BookDtoResponse>>;