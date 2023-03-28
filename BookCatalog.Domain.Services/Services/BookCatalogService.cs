using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Enums;
using BookCatalog.Domain.Interfaces.Repositories;
using BookCatalog.Domain.Interfaces.Services;

namespace BookCatalog.Domain.Services.Services
{
    public class BookCatalogService : IBookCatalogService
    {
        private readonly IBookRepository _bookRepository;
        public BookCatalogService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book> GetBooks(PriceOrderEnum priceOrder)
        {
            var bookList = _bookRepository.GetAllBooks();
            var sortedBookList = OrderByPrice(priceOrder, bookList);

            return sortedBookList;
        }

        private List<Book> OrderByPrice(PriceOrderEnum priceOrder, List<Book> bookList)
        {
            return priceOrder == PriceOrderEnum.Asc
                ? bookList.OrderBy(_ => _.Price).ToList()
                : bookList.OrderByDescending(_ => _.Price).ToList();
        }
    }
}
