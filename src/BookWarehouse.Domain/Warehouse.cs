using System.Collections.Generic;
using System.Linq;
using BookWarehouse.Domain.Books;

namespace BookWarehouse.Domain
{
    public class Warehouse
    {
        private readonly IDictionary<Book, BookShelf> _stock = new Dictionary<Book, BookShelf>();

        public IList<BookShelf> GetBookShelves(IUserContext context)
        {
            return _stock.Values.ToList();
        }

        public BookShelf GetBookShelf(Book book)
        {
            return !_stock.ContainsKey(book)
                ? new BookShelf(book, 0)
                : _stock[book];
        }

        public string ReceiveBooks(Book book, int quantity)
        {
            if (quantity <= 0) return "invalid_quantity";

            var bookshelf = !_stock.ContainsKey(book)
                ? new BookShelf(book, 0)
                : _stock[book];

            _stock[book] = bookshelf.AddBooks(quantity);

            return string.Empty;
        }
    }
}
