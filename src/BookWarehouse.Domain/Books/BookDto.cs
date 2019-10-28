using System;

namespace BookWarehouse.Domain.Books
{
    public class BookDto
    {
        public Guid Id { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Weight { get; set; }

    }
}
