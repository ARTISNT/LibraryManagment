using Application.Abstractions.Repositories;
using Application.Implementation.Commands.Book;
using AutoMapper;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Handers.Commands.Book;

public class CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
    : IRequestHandler<CreateBookCommand, int>
{
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));
        
        var book = mapper.Map<BookEntity>(request.BookDto);
        await bookRepository.Create(book);
        
        return book.Id;
    }
}