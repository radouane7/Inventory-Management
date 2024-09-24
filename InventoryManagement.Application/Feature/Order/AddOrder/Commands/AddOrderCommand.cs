using InventoryManagement.Application.Feature.Order.AddOrder.Dto;
using InventoryManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Order.AddOrder.Commands
{
    public record AddOrderCommand : IRequest<int>
    {
        public AddOrderDto addOrderDto { get; set; }    
    }
}
