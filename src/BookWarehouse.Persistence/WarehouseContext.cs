using System;
using System.Collections.Generic;
using System.Text;
using BookWarehouse.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookWarehouse.Persistence
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions options) : base(options)
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Book>(entity =>
              {
                  entity.Property(e => e.ISBN).HasMaxLength(20);
                  entity.Property(e => e.Title).HasMaxLength(100);
                  entity.Property(e => e.Author).HasMaxLength(50);
              });
        }
    }
}
