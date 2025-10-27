using Application.Abstractions.Services;
using Application.Dto.BookDto;
using Application.Implementation.Queries.Book;
using AutoMapper;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Implementation.Handers.Queries.Book;

public class GetAllBooksQueryHandler :  IRequestHandler<GetAllBooksQuery, IEnumerable<BookDtoResponse>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IBusinessRuleValidationService _businessRuleValidationService;
    
    public GetAllBooksQueryHandler(IBookRepository repository,  IMapper mapper,  IBusinessRuleValidationService businessRuleValidationService)
    {
        _bookRepository = repository;
        _mapper = mapper;
        _businessRuleValidationService = businessRuleValidationService;
    }
    
    public async Task<IEnumerable<BookDtoResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAll();
        _businessRuleValidationService.CheckObjectForNull(books, "Books not found");
        
        return _mapper.Map<IEnumerable<BookDtoResponse>>(books);
    }
}