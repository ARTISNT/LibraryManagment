using Application.Implementation.Commands.Author;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Handers.Commands.Author;

public class CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
    : IRequestHandler<CreateAuthorCommand, int>
{
    public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = mapper.Map<AuthorEntity>(request.AuthorDto);
        await authorRepository.Create(author);
        
        return author.Id;
    }
}