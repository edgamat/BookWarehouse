using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWarehouse.Persistence
{
    public interface IEntityTypeConfiguration
    {
        void Configure(ModelBuilder modelBuilder);
    }
}