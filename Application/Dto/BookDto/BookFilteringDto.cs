using System.ComponentModel.DataAnnotations;

namespace Application.Dto.BookDto;

public class BookFilteringDto
{
    [Range(0, int.MaxValue, ErrorMessage = "AuthorId must be greater than 0")]
    public int? PublishingYear { get; set; }
}