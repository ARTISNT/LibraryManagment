using Application.Abstractions.Repositories;
using Application.Dto.BookDto;
using Application.Implementation.Queries.Book;
using AutoMapper;
using MediatR;

namespace Application.Implementation.Handers.Queries.Book;

public class GetAllBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
    : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDtoResponse>>
{
    public async Task<IEnumerable<BookDtoResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await bookRepository.GetAll(request.BookFilteringDto);
        
        return mapper.Map<IEnumerable<BookDtoResponse>>(books);
    }
}