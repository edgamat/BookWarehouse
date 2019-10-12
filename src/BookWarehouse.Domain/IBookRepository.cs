using System;
using System.Collections.Generic;
using System.Text;

namespace BookWarehouse.Domain
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
