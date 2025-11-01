using Application.Abstractions.Repositories;
using Application.Implementation.Commands.Author;
using AutoMapper;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Handers.Commands.Author;

public class UpdateAuthorCommandHandler(
    IAuthorRepository authorRepository,
    IMapper mapper)
    : IRequestHandler<UpdateAuthorCommand, int>
{
    public async Task<int> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        if(request.Id <= 0)
            throw new ArgumentOutOfRangeException(nameof(request.Id));
        
        var author = mapper.Map<AuthorEntity>(request.AuthorDto);
        await authorRepository.Update(request.Id, author);
        
        return author.Id;
    }
}