using Application.Abstractions.Services;
using Application.Dto.AuthorsDto;
using Application.Implementation.Queries.Author;
using AutoMapper;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Implementation.Handers.Queries.Author;

public class GetAuthorByIdHandler :  IRequestHandler<GetAuthorByIdQuery, AuthorResponseDto>
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;
    private readonly IBusinessRuleValidationService _businessRuleValidationService;

    public GetAuthorByIdHandler(IAuthorRepository repository,  IMapper mapper, IBusinessRuleValidationService businessRuleValidationService)
    {
        _repository = repository;
        _mapper = mapper;
        _businessRuleValidationService = businessRuleValidationService;
    }
    
    public async Task<AuthorResponseDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        _businessRuleValidationService.CheckForValidId(request.Id, "Not valid id");
        
        var author = await _repository.GetById(request.Id);
        _businessRuleValidationService.CheckObjectForNull(author, "Author not found");
        
        return _mapper.Map<AuthorResponseDto>(author);
    }
}