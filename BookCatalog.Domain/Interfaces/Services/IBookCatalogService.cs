using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Enums;
using BookCatalog.Domain.Filters;

namespace BookCatalog.Domain.Interfaces.Services
{
    public interface IBookCatalogService
    {
        List<Book> GetBooks(PriceOrderEnum priceOrder);
        List<Book>GetBooksByFilter(BookCatalogFilter bookCatalogFilter, PriceOrderEnum priceOrder);
        Book GetBookBy(int id);
    }
}
