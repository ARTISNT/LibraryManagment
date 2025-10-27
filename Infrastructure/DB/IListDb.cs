using Domain.Models.Entities;

namespace Infrastructure.DB;

public interface IListDb
{
    public IReadOnlyCollection<BookEntity> Books { get; }
    public IReadOnlyCollection<AuthorEntity> Authors { get; }

    public void Reset();
}