using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Abstractions
{
    public interface IOrderRepo
    {
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void AddOrderItem(OrderItem item);
        void UpdateOrderItem(OrderItem item);
        void RemoveOrderItem(int orderId, int orderItemId);
        Order GetOrder(int id);
        OrderItem GetOrderItem(int id);

    }
}
