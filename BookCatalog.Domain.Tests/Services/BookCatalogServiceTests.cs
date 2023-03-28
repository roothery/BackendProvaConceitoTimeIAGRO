using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Enums;
using BookCatalog.Domain.Interfaces.Repositories;
using BookCatalog.Domain.Interfaces.Services;
using BookCatalog.Domain.Services.Services;
using Moq;

namespace BookCatalog.Domain.Tests.Services
{
    [TestClass]
    public class BookCatalogServiceTests
    {
        private readonly IBookCatalogService _bookCatalogService;
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        public BookCatalogServiceTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _bookCatalogService = new BookCatalogService(_bookRepositoryMock.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            _bookRepositoryMock.Setup(_ => _.GetAllBooks()).Returns(BuildBookCatalog());
        }

        private List<Book> BuildBookCatalog()
        {
            var books = new List<Book>();

            books.Add(new Book
            {
                Name = "Journey to the Center of the Earth",
                Price = 10.00m,
                Specifications = new Specifications
                {
                    OriginallyPublished = "November 25, 1864",
                    Author = "Jules Verne",
                    PageCount = 183,
                    Illustrator = new List<string>
                    {
                        "Édouard Riou"
                    },
                    Genres = new List<string>
                    {
                        "Science Fiction",
                        "Adventure fiction"
                    }
                }
            });

            books.Add(new Book
            {
                Name = "Harry Potter and the Goblet of Fire",
                Price = 7.31m,
                Specifications = new Specifications
                {
                    OriginallyPublished = "July 8, 2000",
                    Author = "J. K. Rowling",
                    PageCount = 636,
                    Illustrator = new List<string>
                    {
                        "Cliff Wright",
                        "Mary GrandPré"
                    },
                    Genres = new List<string>
                    {
                        "Fantasy Fiction",
                        "Drama",
                        "Young adult fiction",
                        "Mystery",
                        "Thriller",
                        "Bildungsroman"
                    }
                }
            });

            books.Add(new Book
            {
                Name = "Fantastic Beasts and Where to Find Them: The Original Screenplay",
                Price = 11.15m,
                Specifications = new Specifications
                {
                    OriginallyPublished = "November 18, 2016",
                    Author = "J. K. Rowling",
                    PageCount = 457,
                    Illustrator = new List<string>
                    {
                        "Cliff Wright"
                    },
                    Genres = new List<string>
                    {
                        "Fantasy Fiction",
                        "Contemporary fantasy",
                        "Screenplay"
                    }
                }
            });

            return books;
        }

        [TestMethod]
        public void Dado_um_arquivo_json_deve_retornar_informacoes_dos_livros()
        {
            var booList = _bookCatalogService.GetBooks(PriceOrderEnum.Asc);

            Assert.IsTrue(booList.Any());
        }
    }
}
