using Application.Abstractions.Services;
using Application.Implementation.Commands.Author;
using Application.Implementation.Commands.Book;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Handers.Commands.Book;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IBusinessRuleValidationService  _businessRuleValidationService;

    public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper,  IBusinessRuleValidationService businessRuleValidationService)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _businessRuleValidationService = businessRuleValidationService;
    }
    
    public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        _businessRuleValidationService.CheckForValidId(request.Id, "Not valid id");
        var book = _mapper.Map<BookEntity>(request.BookDto);
        await _bookRepository.Create(book);
        
        return book.Id;
    }
}