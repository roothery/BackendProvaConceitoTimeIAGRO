using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Enums;

namespace BookCatalog.Domain.Interfaces.Services
{
    public interface IBookCatalogService
    {
        List<Book> GetBooks(PriceOrderEnum priceOrder);
    }
}
