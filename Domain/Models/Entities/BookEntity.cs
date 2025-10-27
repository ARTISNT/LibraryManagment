namespace Domain.Models.Entities;

public class BookEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public int AuthorId { get; set; }
    public int PublishYear { get; set; }
    public ICollection<AuthorEntity> Authors { get; set; } = new List<AuthorEntity>();
}