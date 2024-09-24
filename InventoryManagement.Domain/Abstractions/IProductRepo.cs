using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Abstractions
{
    public interface IProductRepo
    {
        void AddProduct(Product product);
        Product GetProduct(int id);
        int GetStock(int id);
        void UpdateStock(int idProduct, int quantity);

    }
}
