using InventoryManagement.Domain.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class Supplier : Entity
    {
        public Supplier(int Id) : base(Id)
        {

        }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; } 

        public Address address { get; set; }    
        public string Phone { get; set; }

        // Navigation property for related Products
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
