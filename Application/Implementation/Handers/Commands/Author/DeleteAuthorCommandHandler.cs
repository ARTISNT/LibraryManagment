using Application.Abstractions.Services;
using Application.Implementation.Commands.Author;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Implementation.Handers.Commands.Author;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
{
    private readonly IAuthorRepository _repository;
    private readonly IBusinessRuleValidationService  _businessRuleValidationService;

    public DeleteAuthorCommandHandler(IAuthorRepository repository,  IBusinessRuleValidationService businessRuleValidationService)
    {
        _repository = repository;
        _businessRuleValidationService = businessRuleValidationService;
    }
    
    public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        _businessRuleValidationService.CheckForValidId(request.Id, "Id is not valid"); 
        await _repository.Delete(request.Id);
    }
}