using BookCatalog.Domain.Entities;

namespace BookCatalog.Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
    }
}
