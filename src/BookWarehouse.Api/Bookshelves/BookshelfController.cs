using System.Collections.Generic;
using BookWarehouse.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BookWarehouse.Api.Bookshelves
{
    [Route("[controller]")]
    [ApiController]
    public class BookshelfController : ControllerBase
    {
        private readonly Warehouse _warehouse;
        private readonly IUserContext _userContext;

        public BookshelfController(Warehouse warehouse, IUserContext userContext)
        {
            _warehouse = warehouse;
            _userContext = userContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookShelf>> Get()
        {
            return Ok(_warehouse.GetBookShelves(_userContext));
        }
    }
}