using System.Collections.Generic;
using System.Linq;
using BookWarehouse.Domain.SharedKernel;

namespace BookWarehouse.Domain.Books
{
    public class GetListQuery : IQuery<List<BookDto>>
    {
        internal sealed class GetListQueryHandler : IQueryHandler<GetListQuery, List<BookDto>>
        {
            private readonly IBookRepository _repository;

            public GetListQueryHandler(IBookRepository repository)
            {
                _repository = repository;
            }

            public List<BookDto> Handle(GetListQuery query)
            {
                var books = _repository.All();

                return books
                    .Select(x => new BookDto
                    {
                        Id = x.Id,
                        Author = x.Author,
                        ISBN = x.ISBN,
                        Title = x.Title,
                        Weight = x.Weight
                    }).ToList();
            }
        }
    }
}
