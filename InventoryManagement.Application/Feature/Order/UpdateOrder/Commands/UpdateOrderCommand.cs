using InventoryManagement.Application.Feature.Category.AddCategory.Dto;
using InventoryManagement.Application.Feature.Order.UpdateOrder.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Order.UpdateOrder.Commands
{
    public class UpdateOrderCommand :IRequest<int>
    {
        public UpdateOrderDto updateOrderDto { get; set; }
    }
}
