using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Order.AddOrder.Dto
{
    public record AddOrderItemDto (int Id,
        int OrderID , int ProductID,
        int Quantity, decimal UnitPrice); 

}
