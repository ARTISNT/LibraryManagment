using Application.Abstractions.Services;
using Application.Implementation.Commands.Author;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Handers.Commands.Author;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, int>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IBusinessRuleValidationService  _businessRuleValidationService;
    private readonly IMapper _mapper;

    public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper,  IBusinessRuleValidationService businessRuleValidationService)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
        _businessRuleValidationService = businessRuleValidationService;
    }
    
    public async Task<int> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        _businessRuleValidationService.CheckForValidId(request.Id, "Not valid id");
        var author = _mapper.Map<AuthorEntity>(request.AuthorDto);
        await _authorRepository.Update(request.Id, author);
        
        return author.Id;
    }
}