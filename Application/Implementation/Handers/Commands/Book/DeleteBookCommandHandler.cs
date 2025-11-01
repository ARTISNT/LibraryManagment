using Application.Abstractions.Repositories;
using Application.Implementation.Commands.Book;
using MediatR;

namespace Application.Implementation.Handers.Commands.Book;

public class DeleteBookCommandHandler(
    IBookRepository bookRepository)
    : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        if(request.Id <= 0)
            throw new ArgumentOutOfRangeException(nameof(request.Id));
        
        await bookRepository.Delete(request.Id);
    }
}