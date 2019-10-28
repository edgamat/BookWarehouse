using BookWarehouse.Api.Utils;
using BookWarehouse.Domain.Books;
using BookWarehouse.Domain.SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace BookWarehouse.Api.Books
{
    [ApiController]
    [Route("book")]
    public class BookController : BaseController
    {
        private readonly Messages _messages;

        public BookController(Messages messages)
        {
            _messages = messages;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var query = new GetListQuery();

            var books = _messages.Dispatch(query);

            return Ok(books);
        }

        [HttpPost]
        public IActionResult RegisterBook([FromBody] RegisterBookModel model)
        {
            var command = new RegisterBookCommand(model.ISBN, model.Title, model.Author, model.Weight);

            var result = _messages.Dispatch(command);

            return FromResult(result);
        }
    }
}
