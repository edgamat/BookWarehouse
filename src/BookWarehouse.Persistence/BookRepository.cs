using System;
using System.Collections.Generic;
using System.Linq;
using BookWarehouse.Domain.Books;

namespace BookWarehouse.Persistence
{
    public class BookRepository : IBookRepository
    {
        private readonly WarehouseContext _context;

        public BookRepository(WarehouseContext context)
        {
            _context = context;
        }

        public Book FindByKey(Guid id)
        {
            return _context.Set<Book>().Find(id);
        }

        public IEnumerable<Book> All()
        {
            return _context.Set<Book>().ToList();
        }

        public void Insert(Book entity)
        {
            _context.Set<Book>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(Book entity)
        {
            _context.Set<Book>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = FindByKey(id);
            _context.Set<Book>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
