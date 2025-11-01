using Application.Abstractions.Repositories;
using Application.Dto.AuthorsDto;
using Application.Implementation.Queries.Author;
using AutoMapper;
using MediatR;

namespace Application.Implementation.Handers.Queries.Author;

public class GetAuthorByIdHandler(IAuthorRepository repository, IMapper mapper)
    : IRequestHandler<GetAuthorByIdQuery, AuthorResponseDto>
{
    public async Task<AuthorResponseDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        if(request.Id >= 0)
            throw new ArgumentOutOfRangeException(nameof(request.Id));
        
        var author = await repository.GetById(request.Id);
        if(author is null)
            throw new NullReferenceException("Author not found");
        
        return mapper.Map<AuthorResponseDto>(author);
    }
}