using Application.Abstractions.Services;
using Application.Dto.AuthorsDto;
using Application.Implementation.Queries;
using Application.Implementation.Queries.Author;
using AutoMapper;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Implementation.Handers.Queries.Author;

public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery,  IEnumerable<AuthorResponseDto>>
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;
    private readonly IBusinessRuleValidationService _businessRuleValidationService;

    public GetAllAuthorsQueryHandler(IAuthorRepository repository,  IMapper mapper,  IBusinessRuleValidationService businessRuleValidationService)
    {
        _repository = repository;
        _mapper = mapper;
        _businessRuleValidationService = businessRuleValidationService;
    }
    
    public async Task<IEnumerable<AuthorResponseDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _repository.GetAll();
        _businessRuleValidationService.CheckObjectForNull(authors, "Authors not found");
        
        return _mapper.Map<IEnumerable<AuthorResponseDto>>(authors);
    }
}