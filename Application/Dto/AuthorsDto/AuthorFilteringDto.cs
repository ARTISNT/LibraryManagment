using System.ComponentModel.DataAnnotations;

namespace Application.Dto.AuthorsDto;

public class AuthorFilteringDto
{
    public string? Name { get; set; }
    
    
    [Range(0, int.MaxValue, ErrorMessage = "AuthorId must be greater than 0")]
    public bool GetCountOfBooks { get; set; }
}