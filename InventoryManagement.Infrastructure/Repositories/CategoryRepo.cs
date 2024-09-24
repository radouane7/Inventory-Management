using InventoryManagement.Domain.Abstractions;
using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        InventoryDBContext _dbContext;
        public CategoryRepo(InventoryDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public void AddCategory(Category category)
        {
            _dbContext.Add<Category>(category);
          
        }

        public Category GetCategory(int id)
        {
            return _dbContext.categories.FirstOrDefault(p => p.Id == id);
        }
    }
}
