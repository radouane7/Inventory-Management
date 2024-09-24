using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure;
using InventoryManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Tests
{
    public class CategoryTest : IClassFixture<SharedDatabaseFixture>
    {
         private readonly InventoryDBContext _context;
        private readonly CategoryRepo _repo;


        public CategoryTest(SharedDatabaseFixture fixture)
        { 
            _context = new InventoryDBContext(fixture.ContextOptions);

            _repo = new CategoryRepo(_context); 
        }

        [Fact]
        public void AddCategory_ShouldAddCategoryToDbSet()
        {
            // Arrange
            var category = new Category (2) {  CategoryName = "Books" };

            // Act
            _repo.AddCategory(category);
            _context.SaveChanges();

            // Assert
            var categories = _context.categories.ToList();
            Assert.Equal(2, categories.Count);
            Assert.Contains(categories, c => c.CategoryName == "Books");
        }

        [Fact]
        public void GetCategory_ShouldReturnCategory_WhenCategoryExists()
        {
            // Act
            var result = _repo.GetCategory(2);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Id);
            Assert.Equal("Books", result.CategoryName);
        }

    }
}
