using InventoryManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Order.AddOrder.Dto
{
    public record AddOrderDto    
        (int Id,DateTime OrderDate,
         string CustomerName,
         string CustomerEmail,
        List<AddOrderItemDto> OrderItems);
}
