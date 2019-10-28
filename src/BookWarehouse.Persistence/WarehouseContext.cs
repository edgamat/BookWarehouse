using System;
using System.Collections.Generic;
using System.Text;
using BookWarehouse.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookWarehouse.Persistence
{
    public class WarehouseContext : DbContext
    {
        private readonly IEntityTypeConfiguration[] _configurations;

        public WarehouseContext(DbContextOptions options, IEntityTypeConfiguration[] configurations) : base(options)
        {
            _configurations = configurations;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Part of EF Core")]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var map in _configurations)
            {
                map.Configure(modelBuilder);
            }
        }
    }
}
