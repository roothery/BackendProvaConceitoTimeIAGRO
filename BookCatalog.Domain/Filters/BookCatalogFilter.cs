using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Domain.Filters
{
    public class BookCatalogFilter
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string OriginallyPublished { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public string Illustrator { get; set; }
        public string Genres { get; set; }
    }
}
