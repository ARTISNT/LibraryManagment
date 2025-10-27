using Application.Dto.AuthorsDto;
using Application.Implementation.Commands.Author;
using Application.Implementation.Queries.Author;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly ISender _sender;
    
    public AuthorController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var authors = await _sender.Send(new GetAllAuthorsQuery());
        return Ok(authors); 
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var author = await _sender.Send(new GetAuthorByIdQuery(id));
        return Ok(author);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UpdateAuthorDto author)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        await _sender.Send(new UpdateAuthorCommand(id, author));
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateAuthorDto authorInput)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await _sender.Send(new CreateAuthorCommand(authorInput));
        return CreatedAtAction(nameof(GetById), new { Id = result }, null);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _sender.Send(new DeleteAuthorCommand(id));
        return NoContent();
    }
}