using Application.Abstractions.Services;
using Application.Implementation.Commands.Author;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Implementation.Handers.Commands.Author;

public class DeleteAuthorCommandHandler(
    IAuthorRepository repository,
    IBusinessRuleValidationService businessRuleValidationService)
    : IRequestHandler<DeleteAuthorCommand>
{
    public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        businessRuleValidationService.CheckForValidId(request.Id, "Id is not valid"); 
        await repository.Delete(request.Id);
    }
}