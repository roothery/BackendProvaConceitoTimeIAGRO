using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Enums;
using BookCatalog.Domain.Filters;
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
        public void Dado_um_arquivo_json_deve_retornar_informacoes_dos_livros_ordem_ascendente()
        {
            var booList = _bookCatalogService.GetBooks(PriceOrderEnum.ASC);
            var minPrice = 7.31m;

            Assert.AreEqual(booList[0].Price, minPrice);
        }

        [TestMethod]
        public void Dado_um_arquivo_json_deve_retornar_informacoes_dos_livros_ordem_descendente()
        {
            var booList = _bookCatalogService.GetBooks(PriceOrderEnum.DESC);
            var maxPrice = 11.15m;

            Assert.AreEqual(booList[0].Price, maxPrice);
        }

        [TestMethod]
        public void Dado_um_nome_de_livro_valido_deve_retornar_catalogo_de_livros()
        {
            var validName = "Harry Potter";
            BookCatalogFilter filter = new BookCatalogFilter() { Name = validName };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter,PriceOrderEnum.ASC);

            Assert.IsTrue(bookCatalog.FirstOrDefault()?.Name.Contains(validName));
        }

        [TestMethod]
        public void Dado_um_nome_de_livro_invalido_nao_deve_retornar_catalogo_de_livros()
        {
            var invalidName = "Puss in Boots";
            BookCatalogFilter filter = new BookCatalogFilter() { Name = invalidName };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.ASC);

            Assert.IsFalse(bookCatalog.Any());
        }

        [TestMethod]
        public void Dado_um_preco_valido_deve_retornar_catalogo_de_livros()
        {
            var validPrice = 11.15m;
            BookCatalogFilter filter = new BookCatalogFilter() { Price = validPrice };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.DESC);

            Assert.AreEqual(bookCatalog.FirstOrDefault()?.Price, validPrice);
        }

        [TestMethod]
        public void Dado_um_preco_invalido_nao_deve_retornar_catalogo_de_livros()
        {
            var invalidPrice = 157.75m;
            BookCatalogFilter filter = new BookCatalogFilter() { Price = invalidPrice };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.ASC);

            Assert.IsFalse(bookCatalog.Any());
        }

        [TestMethod]
        public void Dado_uma_data_de_publicacao_valida_deve_retornar_catalogo_de_livros()
        {
            var validPublished = "July";
            BookCatalogFilter filter = new BookCatalogFilter() { OriginallyPublished = validPublished };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.DESC);

            Assert.IsTrue(
                bookCatalog.FirstOrDefault()
                ?.Specifications.OriginallyPublished.Contains(validPublished));
        }

        [TestMethod]
        public void Dado_uma_data_de_publicacao_invalida_nao_deve_retornar_catalogo_de_livros()
        {
            var invalidPublished = "January";
            BookCatalogFilter filter = new BookCatalogFilter() { OriginallyPublished = invalidPublished };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.ASC);

            Assert.IsFalse(bookCatalog.Any());
        }

        [TestMethod]
        public void Dado_um_autor_valido_deve_retornar_catalogo_de_livros()
        {
            var validAuthor = "J. K";
            BookCatalogFilter filter = new BookCatalogFilter() { Author = validAuthor };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.DESC);

            Assert.IsTrue(
                bookCatalog.FirstOrDefault()
                ?.Specifications.Author.Contains(validAuthor));
        }

        [TestMethod]
        public void Dado_um_autor_invalido_nao_deve_retornar_catalogo_de_livros()
        {
            var invalidAuthor = "Costantino Fortunato";
            BookCatalogFilter filter = new BookCatalogFilter() { OriginallyPublished = invalidAuthor };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.ASC);

            Assert.IsFalse(bookCatalog.Any());
        }

        [TestMethod]
        public void Dado_um_tamanho_de_pagina_valido_deve_retornar_catalogo_de_livros()
        {
            int validPage = 457;
            BookCatalogFilter filter = new BookCatalogFilter() { PageCount = validPage };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.DESC);

            Assert.AreEqual(bookCatalog.FirstOrDefault()?.Specifications.PageCount, validPage);
        }

        [TestMethod]
        public void Dado_um_tamanho_de_pagina_invalido_nao_deve_retornar_catalogo_de_livros()
        {
            int invalidPage = 897;
            BookCatalogFilter filter = new BookCatalogFilter() { PageCount = invalidPage };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.ASC);

            Assert.IsFalse(bookCatalog.Any());
        }

        [TestMethod]
        public void Dado_um_ilustrador_valido_deve_retornar_catalogo_de_livros()
        {
            var validIllustrator = "Édouard Riou";
            BookCatalogFilter filter = new BookCatalogFilter() { Illustrator = validIllustrator };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.DESC);

            Assert.IsTrue(
                bookCatalog.FirstOrDefault()
                ?.Specifications.Illustrator.Contains(validIllustrator));
        }

        [TestMethod]
        public void Dado_um_ilustrador_invalido_nao_deve_retornar_catalogo_de_livros()
        {
            var invalidIllustrator = "L. Curmer";
            BookCatalogFilter filter = new BookCatalogFilter() { Illustrator = invalidIllustrator };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.ASC);

            Assert.IsFalse(bookCatalog.Any());
        }

        [TestMethod]
        public void Dado_um_genero_valido_deve_retornar_catalogo_de_livros()
        {
            var validGenre = "Fantasy Fiction";
            BookCatalogFilter filter = new BookCatalogFilter() { Genres = validGenre };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.DESC);

            Assert.IsTrue(
                bookCatalog.FirstOrDefault()
                ?.Specifications.Genres.Contains(validGenre));
        }

        [TestMethod]
        public void Dado_um_genero_invalido_nao_deve_retornar_catalogo_de_livros()
        {
            var invalidGenre = "Cyberpunk";
            BookCatalogFilter filter = new BookCatalogFilter() { Genres = invalidGenre };
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, PriceOrderEnum.ASC);

            Assert.IsFalse(bookCatalog.Any());
        }
    }
}
