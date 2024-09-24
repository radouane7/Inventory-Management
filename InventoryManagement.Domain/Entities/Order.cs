using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class Order : Entity
    {
        public Order(int Id) : base(Id)
        {

        }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


    }

}
