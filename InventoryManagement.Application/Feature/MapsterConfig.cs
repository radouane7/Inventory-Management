using InventoryManagement.Application.Feature.Category.AddCategory.Dto;
using InventoryManagement.Application.Feature.Order.AddOrder.Dto;
using InventoryManagement.Application.Feature.Product.AddProduct.Dto;
using InventoryManagement.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature
{
    public class MapsterConfig
    {
        public MapsterConfig()
        {
            // Configure the mapping between AddOrderDto and Order
            TypeAdapterConfig<CategoryDto, Domain.Entities.Category>
                .NewConfig()
                .ConstructUsing(src => new Domain.Entities.Category(src.Id)) // Specify how to construct the Category
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.CategoryName, src => src.CategoryName);


            // Configure the mapping between AddOrderDto and Order
            TypeAdapterConfig<AddOrderDto, Domain.Entities.Order>
                .ForType()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.OrderDate, src => src.OrderDate)
                .Map(dest => dest.CustomerName, src => src.CustomerName)
                .Map(dest => dest.CustomerEmail, src => src.CustomerEmail)
                .Map(dest => dest.OrderItems, src => src.OrderItems.Adapt<List<OrderItem>>());

            // Configure the mapping between AddOrderItemDto and OrderItem
            TypeAdapterConfig<AddOrderItemDto, OrderItem>
                .ForType()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.ProductID, src => src.ProductID)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.UnitPrice, src => src.UnitPrice);

            TypeAdapterConfig<ProductDto, Domain.Entities.Product>
              .ForType()
              .Map(dest => dest.Id, src => src.Id)
              .ConstructUsing(src => new Domain.Entities.Product(src.Id)) // Specify how to construct the Category
 
              .Map(dest => dest.CategoryID, src => src.CategoryID)
              .Map(dest => dest.UnitPrice, src => src.UnitPrice)
              .Map(dest => dest.ProductName, src => new Domain.ValuesObjects.ProductName(src.ProductName))
              .Map(dest => dest.SupplierID, src => src.SupplierID);
        }

    }
}
