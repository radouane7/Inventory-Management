using InventoryManagement.Domain.Abstractions;
using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class ProductRepo :IProductRepo
    {
        InventoryDBContext _dbContext;
        

        public ProductRepo(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProduct(Product product)
        {
            _dbContext.Add(product);
            
        }

        public Product GetProduct(int id)
        {
          return  _dbContext.products.FirstOrDefault(p => p.Id == id);
        }

        public int GetStock(int id) { 
        return _dbContext.stocks.FirstOrDefault(p => p.ProductID == id).Quantity;   
        }

        public void UpdateStock(int idProduct, int quantity)
        {
            var stock = _dbContext.stocks.FirstOrDefault(p => p.ProductID == idProduct);
            stock.Quantity -= quantity;
            _dbContext.Update(stock);
        }

       
    }
}
