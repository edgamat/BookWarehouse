using Microsoft.EntityFrameworkCore;

namespace BookWarehouse.Persistence
{
    public interface IEntityTypeConfiguration
    {
        void Configure(ModelBuilder modelBuilder);
    }
}