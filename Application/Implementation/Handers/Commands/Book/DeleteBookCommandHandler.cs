using Application.Abstractions.Services;
using Application.Implementation.Commands.Book;
using AutoMapper;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Implementation.Handers.Commands.Book;

public class DeleteBookCommandHandler(
    IBookRepository bookRepository,
    IBusinessRuleValidationService businessRuleValidationService)
    : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        businessRuleValidationService.CheckForValidId(request.Id, "Not valid id");
        await bookRepository.Delete(request.Id);
    }
}