using Application.Implementation.Commands.Author;
using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Implementation.Handers.Commands.Author;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
{
    private readonly IAuthorRepository  _authorRepository;
    private readonly IMapper  _mapper;

    public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _mapper.Map<AuthorEntity>(request.AuthorDto);
        await _authorRepository.Create(author);
        
        return author.Id;
    }
}