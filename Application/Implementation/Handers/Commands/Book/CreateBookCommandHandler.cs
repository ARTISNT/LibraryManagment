using Application.Implementation.Commands.Book;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Handers.Commands.Book;

public class CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
    : IRequestHandler<CreateBookCommand, int>
{
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = mapper.Map<BookEntity>(request.BookDto);
        await bookRepository.Create(book);
        
        return book.Id;
    }
}