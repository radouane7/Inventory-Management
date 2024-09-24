using InventoryManagement.Application.Feature.Category.AddCategory.Commands;
using InventoryManagement.Application.Feature.Category.AddCategory.Dto;
using InventoryManagement.Application.Feature.Product.AddProduct.Commands;
using InventoryManagement.Application.Feature.Product.AddProduct.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly ISender _send;
        public ProductController(ISender send)
        {
            _send = send;
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDto _productDto)
        {
            AddProductCommand AddProductCommand = new AddProductCommand { ProductDto = _productDto };
            var res = _send.Send(AddProductCommand);
            return Ok(res);

        }
    }
}
