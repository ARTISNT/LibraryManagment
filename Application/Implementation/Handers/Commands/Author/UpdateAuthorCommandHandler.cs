using Application.Abstractions.Services;
using Application.Implementation.Commands.Author;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Handers.Commands.Author;

public class UpdateAuthorCommandHandler(
    IAuthorRepository authorRepository,
    IMapper mapper,
    IBusinessRuleValidationService businessRuleValidationService)
    : IRequestHandler<UpdateAuthorCommand, int>
{
    public async Task<int> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        businessRuleValidationService.CheckForValidId(request.Id, "Not valid id");
        var author = mapper.Map<AuthorEntity>(request.AuthorDto);
        await authorRepository.Update(request.Id, author);
        
        return author.Id;
    }
}