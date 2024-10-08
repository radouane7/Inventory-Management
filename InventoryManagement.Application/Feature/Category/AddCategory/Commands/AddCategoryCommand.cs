﻿using InventoryManagement.Application.Feature.Category.AddCategory.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Feature.Category.AddCategory.Commands
{
    public sealed record AddCategoryCommand :IRequest<int>
    {
        public CategoryDto CategoryDto { get; set; }   
    }
}
