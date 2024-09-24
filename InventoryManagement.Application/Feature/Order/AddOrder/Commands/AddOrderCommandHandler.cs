using InventoryManagement.Domain.Abstractions;
using InventoryManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Order.AddOrder.Commands
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, int>
    {
        IOrderRepo _orderRepo;
        IProductRepo _productRepo;
        public readonly IUnitOfWork _unitOfWork;
        public AddOrderCommandHandler(IOrderRepo repo, IProductRepo productRepo, IUnitOfWork unitOfWork)
        {
            _orderRepo = repo;
            _productRepo = productRepo;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {

            //Can we use mapster here ?

            Domain.Entities.Order order = new Domain.Entities.Order(request.addOrderDto.Id)
            { 
                CustomerEmail = request.addOrderDto.CustomerEmail,
                CustomerName = request.addOrderDto.CustomerName,
                OrderDate = request.addOrderDto.OrderDate  
            };

            foreach (var item in request.addOrderDto.OrderItems)
            {
                var product = _productRepo.GetProduct( item.ProductID) ;
                if (product == null)
                    throw new Exception($"Product with ID {item.ProductID} not found.");

                var orderItem = new OrderItem(item.Id) // Similarly, handle the ID generation
                {
                    Product = product,
                    ProductID = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Order = order
                };

                order.OrderItems.Add(orderItem);
                //Update Stock
                _productRepo.UpdateStock(product.Id,item.Quantity);
            }

            _orderRepo.CreateOrder(order);
            _unitOfWork.commit();

            return Task.FromResult(order.Id);  

        }
    }
}
