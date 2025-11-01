using Application.Abstractions.Repositories;
using Application.Implementation.Commands.Author;
using MediatR;

namespace Application.Implementation.Handers.Commands.Author;

public class DeleteAuthorCommandHandler(
    IAuthorRepository repository)
    : IRequestHandler<DeleteAuthorCommand>
{
    public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        if(request.Id <= 0)
            throw new ArgumentOutOfRangeException(nameof(request.Id));
        
        await repository.Delete(request.Id);
    }
}