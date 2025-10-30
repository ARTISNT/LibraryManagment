namespace Application.Dto.AuthorsDto;

public class AuthorResponseWithBookCountDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public DateTime DateOfBirthday { get; set; }
    public int? BooksCount { get; set; }
}