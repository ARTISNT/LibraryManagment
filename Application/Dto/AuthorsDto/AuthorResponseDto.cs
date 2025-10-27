namespace Application.Dto.AuthorsDto;

public class AuthorResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public DateTime DateOfBirthday { get; set; }
}