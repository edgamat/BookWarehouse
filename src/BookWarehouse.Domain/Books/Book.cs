using System;

namespace BookWarehouse.Domain.Books
{
    public class Book
    {
        public Guid Id { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Weight { get; set; }

        public override bool Equals(object obj)
        {
            var valueObject = obj as Book;

            if (ReferenceEquals(valueObject, null))
                return false;

            return valueObject.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
