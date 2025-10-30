using Application.Abstractions.Services;
using Application.Dto.AuthorsDto;
using Application.Implementation.Queries.Author;
using AutoMapper;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Implementation.Handers.Queries.Author;

public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery,  IEnumerable<AuthorResponseWithBookCountDto>>
{
    private readonly IBusinessRuleValidationService _businessRuleValidationService;
    private readonly IAuthorsFilteringService _authorsFilteringService;
    

    public GetAllAuthorsQueryHandler(IBusinessRuleValidationService businessRuleValidationService,  IAuthorsFilteringService authorsFilteringService)
    {
        _authorsFilteringService = authorsFilteringService;
        _businessRuleValidationService = businessRuleValidationService;
    }
    
    public async Task<IEnumerable<AuthorResponseWithBookCountDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _authorsFilteringService.ApplyFiltering(request.AuthorFilteringDto);
        _businessRuleValidationService.CheckObjectForNull(authors, "Authors not found");
        
        return authors;
    }
}