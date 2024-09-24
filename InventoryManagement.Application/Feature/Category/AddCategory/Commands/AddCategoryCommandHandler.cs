using InventoryManagement.Application.Feature.Order.AddOrder.Dto;
using InventoryManagement.Domain.Abstractions;
using InventoryManagement.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Category.AddCategory.Commands
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, int>
    {
        public readonly ICategoryRepo _categoryRepo;
        public readonly IUnitOfWork _unitOfWork;

        public AddCategoryCommandHandler(ICategoryRepo categoryRepo, IUnitOfWork unitOfWork = null)
        {
            _categoryRepo = categoryRepo;
            _unitOfWork = unitOfWork;
        }

        public Task<int> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        { 
            InventoryManagement.Domain.Entities.Category category = 
                request.CategoryDto.Adapt<InventoryManagement.Domain.Entities.Category>();
            _categoryRepo.AddCategory(category);
            _unitOfWork.commit();   
            return Task.FromResult(1);
        }
    }
}
