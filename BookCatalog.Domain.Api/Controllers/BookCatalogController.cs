using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Enums;
using BookCatalog.Domain.Filters;
using BookCatalog.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Domain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCatalogController : ControllerBase
    {
        private readonly IBookCatalogService _bookCatalogService;
        private readonly IShippingService _shippingService;

        public BookCatalogController(
            IBookCatalogService bookCatalogService,
            IShippingService shippingService)
        {
            _bookCatalogService = bookCatalogService;
            _shippingService = shippingService;
        }

        /// <summary>
        /// Retorna catálogo de livros convertido do JSON, com escolha de ordenação.
        /// </summary>
        /// <param name="priceOrder"></param>
        /// <returns></returns>
        [HttpGet("book-catalog")]
        public ActionResult<List<Book>> GetBookCatalog(
            [FromQuery]PriceOrderEnum priceOrder = PriceOrderEnum.ASC)
        {
            var bookCatalog = _bookCatalogService.GetBooks(priceOrder);
            return Ok(bookCatalog);
        }

        /// <summary>
        /// Retorna catálogo de livros baseado nas opções de filtros aplicados.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="priceOrder"></param>
        /// <returns></returns>
        [HttpGet("book-catalog-filter")]
        public ActionResult<List<Book>> GetBookCatalogFiltered(
            [FromQuery]BookCatalogFilter filter, PriceOrderEnum priceOrder = PriceOrderEnum.ASC)
        {
            var bookCatalog = _bookCatalogService.GetBooksByFilter(filter, priceOrder);
            return Ok(bookCatalog);
        }

        /// <summary>
        /// Retorna um determinado livro com o valor do frete calculado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("book-shipping")]
        public ActionResult<Book> GetBookShipping(int id)
        {
            var book = _bookCatalogService.GetBookBy(id);

            if (book == null) { return NoContent(); }

            var bookShipping = _shippingService.CalculateShipping(book.Price);
            return Ok(new { bookShipping, book });
        }
    }
}
