namespace Application.Dto.BookDto;

public class BookDtoResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public int AuthorId { get; set; }
    public int PublishYear { get; set; }
}