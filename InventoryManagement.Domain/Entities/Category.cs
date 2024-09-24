using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class Category :Entity
    {
        public Category(int Id) : base(Id)
        {

        }

        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();


    }
}
