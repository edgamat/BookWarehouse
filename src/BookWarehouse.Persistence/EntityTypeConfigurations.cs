using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWarehouse.Persistence
{
    public static class EntityTypeConfigurations
    {
        public static readonly IEntityTypeConfiguration[] All =
        {
             new BookConfiguration()
        };
    }
}
