using System;
using BookWarehouse.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace BookWarehouse.Persistence
{
    public class BookConfiguration : IEntityTypeConfiguration
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.Entity<Book>(builder =>
            {
                builder.Property(e => e.ISBN).HasMaxLength(20);
                builder.Property(e => e.Title).HasMaxLength(100);
                builder.Property(e => e.Author).HasMaxLength(50);
            });
        }
    }
}