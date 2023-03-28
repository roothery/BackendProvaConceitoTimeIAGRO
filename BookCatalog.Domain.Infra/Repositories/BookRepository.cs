using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Interfaces.Repositories;
using Newtonsoft.Json.Linq;

namespace BookCatalog.Domain.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        public List<Book> GetAllBooks()
        {
            List<Book> bookList = new List<Book>();

            var jsonPath = GetPathJson();

            var jsonText = File.ReadAllText(jsonPath);
            var jsonArray = JArray.Parse(jsonText);

            bookList = jsonArray.Select(_ => new Book
            {
                Id = (int)_["id"],
                Name = (string)_["name"],
                Price = (decimal)_["price"],
                Specifications = new Specifications
                {
                    OriginallyPublished = (string)_["specifications"]["Originally published"],
                    Author = (string)_["specifications"]["Author"],
                    PageCount = (int)_["specifications"]["Page count"],
                    Illustrator = ConvertToStringList(_["specifications"]["Illustrator"]),
                    Genres = ConvertToStringList(_["specifications"]["Genres"])
                }
            }).ToList();

            return bookList;
        }

        private string GetPathJson()
        {
            var baseDirectory = AppContext.BaseDirectory.Split("Api");
            var path = $"{baseDirectory[0]}Infra";

            return Path.Combine(path, "Data", "books.json");
        }

        private List<string> ConvertToStringList(JToken? jToken)
        {
            return jToken.Type == JTokenType.Array
                    ? jToken.ToObject<List<string>>()
                    : new List<string> { jToken.Value<string>() };
        }
    }
}
