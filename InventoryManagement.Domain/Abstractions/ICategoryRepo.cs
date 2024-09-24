using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Abstractions
{
    public interface ICategoryRepo
    {
        void AddCategory(Category category);
        Category GetCategory(int id);   

    }
}
