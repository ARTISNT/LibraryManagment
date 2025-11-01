using Application.Abstractions.Repositories;
using Application.Implementation.Commands.Author;
using AutoMapper;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Handers.Commands.Author;

public class CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
    : IRequestHandler<CreateAuthorCommand, int>
{
    public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
            throw new ArgumentNullException(nameof(request));
        
        var author = mapper.Map<AuthorEntity>(request.AuthorDto);
        await authorRepository.Create(author);
        
        return author.Id;
    }
}