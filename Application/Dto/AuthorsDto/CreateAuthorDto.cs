using System.ComponentModel.DataAnnotations;
using Application.Attributes;

namespace Application.Dto.AuthorsDto;

public class CreateAuthorDto
{
    [Required]
    [MinLength(3, ErrorMessage =  "Name must be at least 3 characters")]
    [MaxLength(20, ErrorMessage =  "Name cannot exceed 20 characters")]
    public string Name { get; set; } = String.Empty;
    
    [Required]
    [DataType(DataType.Date)]
    [NotInFuture(ErrorMessage = "Date must don't be in the future")]
    public DateTime DateOfBirthday { get; set; }
}