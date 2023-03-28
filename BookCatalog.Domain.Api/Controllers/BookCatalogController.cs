using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Enums;
using BookCatalog.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Domain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCatalogController : ControllerBase
    {
        private readonly IBookCatalogService _bookCatalogService;

        public BookCatalogController(
            IBookCatalogService bookCatalogService)
        {
            _bookCatalogService = bookCatalogService;
        }

        // GET: api/<BookCatalogController>
        [HttpGet("books")]
        public ActionResult<List<Book>> GetAllBookCatalogs(PriceOrderEnum priceOrder = PriceOrderEnum.Asc)
        {
            var bookList = _bookCatalogService.GetBooks(priceOrder);
            return Ok(bookList);
        }

        // GET api/<BookCatalogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookCatalogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookCatalogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookCatalogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
