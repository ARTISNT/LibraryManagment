using Application.Abstractions.Repositories;
using Application.Dto.AuthorsDto;
using Application.Implementation.Queries.Author;
using AutoMapper;
using MediatR;

namespace Application.Implementation.Handers.Queries.Author;

public class GetAllAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
    : IRequestHandler<GetAllAuthorsQuery, IEnumerable<AuthorResponseDto>>
{
    public async Task<IEnumerable<AuthorResponseDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await authorRepository.GetAll(request.AuthorFilteringDto);
        
        return mapper.Map<IEnumerable<AuthorResponseDto>>(authors);
    }
}