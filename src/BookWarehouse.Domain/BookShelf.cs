namespace BookWarehouse.Domain
{
    public class BookShelf
    {
        public BookShelf(Book book, int quantity)
        {
            Book = book;
            Quantity = quantity;
        }

        public Book Book { get; set; }

        public int Quantity { get; set; }

        public BookShelf AddBooks(int quantity)
        {
            return new BookShelf(Book, Quantity + quantity);
        }

        public BookShelf RemoveBooks(int quantity)
        {
            return new BookShelf(Book, Quantity - quantity);
        }
    }
}
