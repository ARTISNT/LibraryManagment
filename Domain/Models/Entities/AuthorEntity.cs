namespace Domain.Models.Entities;

public class AuthorEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public DateTime DateOfBirthday { get; set; }
    public ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();
}