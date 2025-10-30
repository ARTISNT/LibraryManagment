using Application.Abstractions.Services;
using Application.Dto.BookDto;
using Application.Implementation.Queries.Book;
using AutoMapper;
using MediatR;

namespace Application.Implementation.Handers.Queries.Book;

public class GetAllBooksQueryHandler :  IRequestHandler<GetAllBooksQuery, IEnumerable<BookDtoResponse>>
{
    private readonly IBooksFilteringService _booksFilteringService;
    private readonly IBusinessRuleValidationService _businessRuleValidationService;
    
    public GetAllBooksQueryHandler(IBooksFilteringService booksFilteringService, IBusinessRuleValidationService businessRuleValidationService)
    {
        _booksFilteringService = booksFilteringService;
        _businessRuleValidationService = businessRuleValidationService;
    }
    
    public async Task<IEnumerable<BookDtoResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _booksFilteringService.ApplyFiltering(request.BookFilteringDto);
        _businessRuleValidationService.CheckObjectForNull(books, "Books not found");

        return books;
    }
}