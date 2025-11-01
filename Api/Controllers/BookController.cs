using Application.Dto.BookDto;
using Application.Implementation.Commands.Book;
using Application.Implementation.Queries.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] BookFilteringDto filteringDto)
    {
        var books = await sender.Send(new GetAllBooksQuery(filteringDto));
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var book = await sender.Send(new GetBookByIdQuery(id));
        return Ok(book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookDto bookDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        await sender.Send(new UpdateBookCommand(id, bookDto));
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookDto bookDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await sender.Send(new CreateBookCommand(bookDto));
        return CreatedAtAction(nameof(GetById), new { Id = result }, null);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await sender.Send(new DeleteBookCommand(id));
        return NoContent();
    }
}