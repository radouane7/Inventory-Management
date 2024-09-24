using InventoryManagement.Domain.Abstractions;
using InventoryManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Order.UpdateOrder.Commands
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        IOrderRepo _orderRepo;
        IProductRepo _productRepo;
        public readonly IUnitOfWork _unitOfWork;
        public UpdateOrderCommandHandler(IOrderRepo repo, IProductRepo productRepo, IUnitOfWork unitOfWork)
        {
            _orderRepo = repo;
            _productRepo = productRepo;
            _unitOfWork = unitOfWork;
        }
        public Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Order order = _orderRepo.GetOrder(request.updateOrderDto.Id); 

            order.CustomerEmail = request.updateOrderDto.CustomerEmail;
            order.CustomerName = request.updateOrderDto.CustomerName;
            order.OrderDate = request.updateOrderDto.OrderDate;


            foreach (var item in request.updateOrderDto.OrderItems)
            {  
                var orderItem = _orderRepo.GetOrderItem(item.Id)!; 

                orderItem.Quantity = item.Quantity;
                orderItem.UnitPrice = item.UnitPrice;

                _orderRepo.UpdateOrderItem(orderItem);
                //Update Stock
               // _productRepo.UpdateStock(product.Id, item.Quantity);
            }
            _orderRepo.UpdateOrder(order);
            _unitOfWork.commit();
            return Task.FromResult(0);
        }
    }
}
