using Domain.Models.Entities;

namespace Infrastructure.DB;

public class ListDb : IListDb
{
    private List<BookEntity> _books =  new();
    private List<AuthorEntity> _authors =   new();

    public ListDb()
    {
        SeedData();
    }

    public IReadOnlyCollection<BookEntity> Books => _books;
    public IReadOnlyCollection<AuthorEntity> Authors => _authors;
    
    private void SeedData()
    {
        _books.Clear();
        _authors.Clear();
        
        _books =
        [
            new()
            {
                AuthorId = 2,
                Id = 1,
                PublishYear = DateTime.Now.Year,
                Title = "The Witcher's Baptism of Fire",
                Authors = new List<AuthorEntity>
                {
                    _authors.FirstOrDefault(a => a.Id == 2)
                }
            },

            new()
            {
                AuthorId = 1,
                Id = 2,
                PublishYear = DateTime.Now.Year,
                Title = "Pale fire",
                Authors = new List<AuthorEntity>
                {
                    _authors.FirstOrDefault(a => a.Id == 1)
                }
            }
        ];
        _authors =
        [
            new()
            {
                DateOfBirthday = DateTime.Parse("07.05.2002"),
                Id = 1,
                Name = "Anjey Sapkovsky",
                Books = new List<BookEntity>
                {
                    _books.FirstOrDefault(b => b.Id == 1)
                }
            },

            new()
            {
                DateOfBirthday = DateTime.Parse("07.05.2002"),
                Id = 2,
                Name = "Vladimir Nabokov",
                Books = new List<BookEntity>()
                {
                    _books.FirstOrDefault(b => b.Id == 2)
                }
            }
        ];
    }

    public void Reset()
    {
        SeedData();
    }
}