using InventoryManagement.Application.Feature.Category.AddCategory.Commands;
using InventoryManagement.Application.Feature.Category.AddCategory.Dto;
using InventoryManagement.Application.Feature.Category.AddCategory.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ISender _send;
        readonly IMediator  _mediator;

        public CategoryController(ISender send, IMediator mediator)
        {
            _send = send;
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryDto _categoryDto)
        { 
          AddCategoryCommand addCategoryCommand = new AddCategoryCommand { CategoryDto = _categoryDto }; 
            //  AddCategoryNotification addCategoryNotification = new AddCategoryNotification { CategoryDto = _categoryDto };   
           var res = _send.Send(addCategoryCommand);   
           // _mediator.Publish(addCategoryNotification);
            return Ok(res);
            // return Ok();
        }
    }
}
