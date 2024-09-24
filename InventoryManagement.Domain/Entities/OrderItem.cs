using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(int Id) : base(Id)
        {

        }
        public Order Order { get; set; }
        public int OrderID { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } 
    }

}
