using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    [Table("categories")]

    public class Category :Entity
    {
        
        public Category() : base(0) { }

        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();


    }
}
