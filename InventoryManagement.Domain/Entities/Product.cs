using InventoryManagement.Domain.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class Product : Entity
    {

        public Product(int Id) : base(Id)
        {

        }
        public ProductName ProductName { get; set; }     
        public decimal UnitPrice { get; set; }

        public Supplier Supplier { get; set; }  
        public int SupplierID { get; set; }
        public Category Category { get; set; }  
        public int CategoryID { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }

}
