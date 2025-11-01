using Application.Abstractions.Repositories;
using Application.Dto.BookDto;
using Application.Implementation.Queries.Book;
using AutoMapper;
using MediatR;

namespace Application.Implementation.Handers.Queries.Book;

public class GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
    : IRequestHandler<GetBookByIdQuery, BookDtoResponse>
{
    public async Task<BookDtoResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        if(request.Id >= 0)
            throw new ArgumentOutOfRangeException(nameof(request.Id));
        
        var book = await bookRepository.GetById(request.Id);
        if(book is null)
            throw new NullReferenceException("Book not found");
        
        return mapper.Map<BookDtoResponse>(book);
    }
}