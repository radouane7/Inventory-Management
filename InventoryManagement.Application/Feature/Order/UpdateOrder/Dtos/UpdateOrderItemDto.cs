using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Order.UpdateOrder.Dtos
{
    public record UpdateOrderItemDto(int Id,
       int OrderID, int ProductID,
       int Quantity, decimal UnitPrice);
}
