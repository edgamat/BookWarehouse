using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWarehouse.Api.Books
{
    public class RegisterBookModel
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Weight { get; set; }
    }
}
