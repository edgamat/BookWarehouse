using BookWarehouse.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWarehouse.Persistence
{
    public class BookMap : IEntityTypeConfiguration, IEntityTypeConfiguration<Book>
    {
        public void Configure(ModelBuilder modelBuilder) => Configure(modelBuilder.Entity<Book>());

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(e => e.ISBN).HasMaxLength(20);
            builder.Property(e => e.Title).HasMaxLength(100);
            builder.Property(e => e.Author).HasMaxLength(50);
        }
    }
}