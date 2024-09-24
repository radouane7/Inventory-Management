using FluentValidation;
using InventoryManagement.Application.Feature.Order.AddOrder.Dto;
using InventoryManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Order.AddOrder.Commands
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        readonly IProductRepo _repo;

        public AddOrderCommandValidator(IProductRepo repo)
        {
            _repo = repo;
            RuleForEach(cmd => cmd.addOrderDto.OrderItems).Must(IsStockDisponible)
            .WithMessage($"The quantity requested exceeds the available stock.");
            RuleFor(p => p.addOrderDto.CustomerEmail).EmailAddress().WithMessage("Email is not valid");

        }

        bool IsStockDisponible(AddOrderItemDto orderItemDto)
        {
            var qty = _repo.GetStock(orderItemDto.ProductID);
            return qty >= orderItemDto.Quantity;
        }
    }
}
