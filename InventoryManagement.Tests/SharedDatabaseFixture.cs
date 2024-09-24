using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Tests
{
    public class SharedDatabaseFixture : IDisposable
    {
         public DbContextOptions<InventoryDBContext> ContextOptions { get; }
        private readonly InventoryDBContext _context;


        public SharedDatabaseFixture()
        {
            // Configure the in-memory database
            ContextOptions = new DbContextOptionsBuilder<InventoryDBContext>()
                .UseInMemoryDatabase("InventoryTestDb") // Shared in-memory database
                .Options;

            _context = new InventoryDBContext(ContextOptions);

            // Seed the database
            _context.Database.EnsureCreated(); // Ensure the database is created
            if (!_context.categories.Any())
            {
                _context.categories.Add(new Category (1) { CategoryName = "Electronics" });
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
