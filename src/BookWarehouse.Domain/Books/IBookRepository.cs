using System;
using System.Collections.Generic;

namespace BookWarehouse.Domain.Books
{
    public interface IBookRepository
    {
        Book FindByKey(Guid id);

        IEnumerable<Book> All();

        void Insert(Book entity);

        void Update(Book entity);

        void Delete(Guid id);
    }
}
