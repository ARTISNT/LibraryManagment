using Application.Abstractions.Services;
using Application.Implementation.Commands.Author;
using Application.Implementation.Commands.Book;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Handers.Commands.Book;

public class UpdateBookCommandHandler(
    IBookRepository bookRepository,
    IMapper mapper,
    IBusinessRuleValidationService businessRuleValidationService)
    : IRequestHandler<UpdateBookCommand, int>
{
    public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        businessRuleValidationService.CheckForValidId(request.Id, "Not valid id");
        var book = mapper.Map<BookEntity>(request.BookDto);
        await bookRepository.Update(request.Id, book);
        
        return book.Id;
    }
}