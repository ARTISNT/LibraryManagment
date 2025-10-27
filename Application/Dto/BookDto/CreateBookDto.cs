using System.ComponentModel.DataAnnotations;
using Application.Attributes;

namespace Application.Dto.BookDto;

public class CreateBookDto
{
    [Required]
    [MinLength(3, ErrorMessage =  "Title must be at least 3 characters")]
    [MaxLength(50, ErrorMessage =  "Title cannot exceed 50 characters")]
    public string Title { get; set; } = String.Empty;
    
    [Required]
    [ValidPublishYearAttribute(0, ErrorMessage = "Year must be between 0 and 2025")]
    public int PublishYear { get; set; }
}