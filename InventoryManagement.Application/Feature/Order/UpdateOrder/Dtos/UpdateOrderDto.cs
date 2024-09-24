using InventoryManagement.Application.Feature.Order.AddOrder.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Order.UpdateOrder.Dtos
{
    public record UpdateOrderDto
       (int Id, DateTime OrderDate,
        string CustomerName,
        string CustomerEmail,
       List<UpdateOrderItemDto> OrderItems);
}
