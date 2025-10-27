using Application.Dto.BookDto;
using MediatR;

namespace Application.Implementation.Queries.Book;

public record GetBookByIdQuery(int Id) : IRequest<BookDtoResponse>;