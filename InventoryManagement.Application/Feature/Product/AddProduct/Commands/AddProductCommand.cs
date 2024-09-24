using InventoryManagement.Application.Feature.Product.AddProduct.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Product.AddProduct.Commands
{
    public class AddProductCommand : IRequest<int>
    {
        public ProductDto ProductDto { get; set; }
    }
}
