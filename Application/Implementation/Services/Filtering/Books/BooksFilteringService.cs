using Application.Abstractions.Services;
using Application.Dto.BookDto;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementation.Services.Filtering.Books;

public class BooksFilteringService  : IBooksFilteringService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BooksFilteringService(IBookRepository bookRepository,  IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<BookDtoResponse>> ApplyFiltering(BookFilteringDto bookFilteringDto)
    {
        var query = _bookRepository.GetAll();

        if (bookFilteringDto.PublishingYear.HasValue)
            query = query.Where(b => b.PublishYear >= bookFilteringDto.PublishingYear);

        var result = await query.ToListAsync();
        return _mapper.Map<IEnumerable<BookDtoResponse>>(result);
    }
}