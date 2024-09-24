using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class Stock :Entity
    {
        //
        // Un produit peut etre acheté par pluisieurs suppliers
        // 
        public Stock(int Id) : base(Id)
        {
                
        }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
    }

}
