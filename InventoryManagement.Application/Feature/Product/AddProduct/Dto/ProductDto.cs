using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Product.AddProduct.Dto
{
    public record ProductDto (int Id, string ProductName,
        decimal UnitPrice, int SupplierID, int CategoryID);
    
}
