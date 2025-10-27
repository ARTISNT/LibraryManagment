using Application.Abstractions.Services;
using Application.Implementation.Commands.Book;
using AutoMapper;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Implementation.Handers.Commands.Book;

public class DeleteBookCommandHandler :  IRequestHandler<DeleteBookCommand>
{
    private readonly IBookRepository _bookRepository;
    private readonly IBusinessRuleValidationService _businessRuleValidationService;

    public DeleteBookCommandHandler(IBookRepository bookRepository,  IBusinessRuleValidationService businessRuleValidationService)
    {
        _bookRepository = bookRepository;
        _businessRuleValidationService = businessRuleValidationService;
    }
    
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        _businessRuleValidationService.CheckForValidId(request.Id, "Not valid id");
        await _bookRepository.Delete(request.Id);
    }
}