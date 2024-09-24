using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Category.AddCategory.Commands
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(p => p.CategoryDto.CategoryName).NotEmpty().WithMessage("Name khawi");
        }
    }
}
