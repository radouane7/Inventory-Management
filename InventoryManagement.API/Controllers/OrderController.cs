using InventoryManagement.Application.Feature.Category.AddCategory.Commands;
using InventoryManagement.Application.Feature.Category.AddCategory.Dto;
using InventoryManagement.Application.Feature.Order.AddOrder.Commands;
using InventoryManagement.Application.Feature.Order.AddOrder.Dto;
using InventoryManagement.Application.Feature.Order.UpdateOrder.Commands;
using InventoryManagement.Application.Feature.Order.UpdateOrder.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly ISender _send;

        public OrderController(ISender send)
        {
            _send = send;
        }
        [HttpPost]
        public IActionResult AddOrder(AddOrderDto _addOrderDto)
        {
            AddOrderCommand addOrderCommand = new AddOrderCommand { addOrderDto = _addOrderDto };
            var res = _send.Send(addOrderCommand);
            return Ok(res); 
        }

        [HttpPut]
        public IActionResult UpdateOrder(UpdateOrderDto _addOrderDto)
        {
            UpdateOrderCommand  addOrderCommand = new UpdateOrderCommand { updateOrderDto = _addOrderDto };
            var res = _send.Send(addOrderCommand);
            return Ok(res);
        }
    }
}
