using Application.Abstractions.Repositories;
using Application.Implementation.Commands.Book;
using AutoMapper;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Handers.Commands.Book;

public class UpdateBookCommandHandler(
    IBookRepository bookRepository,
    IMapper mapper)
    : IRequestHandler<UpdateBookCommand, int>
{
    public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        if(request.Id <= 0)
            throw new ArgumentOutOfRangeException(nameof(request.Id));
        
        var book = mapper.Map<BookEntity>(request.BookDto);
        await bookRepository.Update(request.Id, book);
        
        return book.Id;
    }
}