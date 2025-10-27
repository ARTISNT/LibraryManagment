using Application.Abstractions.Services;
using Application.Dto.BookDto;
using Application.Implementation.Queries.Book;
using AutoMapper;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Implementation.Handers.Queries.Book;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDtoResponse>
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;
    private readonly IBusinessRuleValidationService _businessRuleValidationService;

    public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper,  IBusinessRuleValidationService businessRuleValidationService)
    {
        _repository = bookRepository;
        _mapper = mapper;
        _businessRuleValidationService = businessRuleValidationService;
    }

    public async Task<BookDtoResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        _businessRuleValidationService.CheckForValidId(request.Id, "Not valid Id");
        var book = await _repository.GetById(request.Id);
        _businessRuleValidationService.CheckObjectForNull(book, "Book not found");
        
        return _mapper.Map<BookDtoResponse>(book);
    }
}