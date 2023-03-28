using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Enums;
using BookCatalog.Domain.Filters;
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
            var bookCatalog = OrderByPrice(priceOrder, bookList);

            return bookCatalog;
        }

        public List<Book> GetBooksByFilter(BookCatalogFilter bookCatalogFilter, PriceOrderEnum priceOrder)
        {
            var bookList = _bookRepository.GetAllBooks();

            var bookCatalog = (from books in bookList
                               where
                                    (string.IsNullOrEmpty(bookCatalogFilter.Name) || books.Name.Contains(bookCatalogFilter.Name)) &&
                                    (!bookCatalogFilter.Price.HasValue || books.Price == bookCatalogFilter.Price) &&
                                    (string.IsNullOrEmpty(bookCatalogFilter.OriginallyPublished) || books.Specifications.OriginallyPublished.Contains(bookCatalogFilter.OriginallyPublished)) &&
                                    (string.IsNullOrEmpty(bookCatalogFilter.Author) || books.Specifications.Author.Contains(bookCatalogFilter.Author)) &&
                                    (!bookCatalogFilter.PageCount.HasValue || bookCatalogFilter.PageCount == books.Specifications.PageCount) &&
                                    (string.IsNullOrEmpty(bookCatalogFilter.Illustrator) || books.Specifications.Illustrator.Contains(bookCatalogFilter.Illustrator)) &&
                                    (string.IsNullOrEmpty(bookCatalogFilter.Genres) || books.Specifications.Genres.Contains(bookCatalogFilter.Genres))
                               select books)
                               .ToList();

            return OrderByPrice(priceOrder, bookCatalog);
        }

        public Book GetBookBy(int id)
        {
            var bookList = _bookRepository.GetAllBooks();
            var book = bookList.FirstOrDefault(_ => _.Id == id);

            return book;
        }

        private List<Book> OrderByPrice(PriceOrderEnum priceOrder, List<Book> bookList)
        {
            if (!bookList.Any())
                return bookList;

            return priceOrder == PriceOrderEnum.ASC
                ? bookList.OrderBy(_ => _.Price).ToList()
                : bookList.OrderByDescending(_ => _.Price).ToList();
        }
    }
}
