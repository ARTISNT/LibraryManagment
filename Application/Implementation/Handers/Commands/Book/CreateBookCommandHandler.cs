using Application.Implementation.Commands.Book;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Handers.Commands.Book;

public class CreateBookCommandHandler :  IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<BookEntity>(request.BookDto);
        await _bookRepository.Create(book);
        
        return book.Id;
    }
}