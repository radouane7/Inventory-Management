using InventoryManagement.Application.Feature.Category.AddCategory.Dto;
using InventoryManagement.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Category.GetCategory.Queries
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto> 
    {
        public readonly ICategoryRepo _categoryRepo;
        public readonly IUnitOfWork _unitOfWork;

        public GetCategoryQueryHandler(ICategoryRepo categoryRepo, IUnitOfWork unitOfWork)
        {
            _categoryRepo = categoryRepo;
            _unitOfWork = unitOfWork;
        }
        public   Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = _categoryRepo.GetCategory(request.id);
            return Task.FromResult(new CategoryDto(request.id, category.CategoryName));// { CategoryName = category.CategoryName, Id = request.id  });
          //  return new CategoryDto(request.id, category.CategoryName);
        }
    }
}
