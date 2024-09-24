using InventoryManagement.Domain.Abstractions;
using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        InventoryDBContext dbContext;

        public OrderRepo(InventoryDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddOrderItem(OrderItem item)
        {
            dbContext.Add(item);
        }

        public void CreateOrder(Order order)
        {
            dbContext.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            dbContext.Update(order);
        }

        public Order GetOrder(int id)
        {
            return dbContext.orders.FirstOrDefault(p => p.Id == id)!; 
        }

        public OrderItem GetOrderItem(int id)
        {
            return dbContext.ordersItem.FirstOrDefault(p => p.Id == id)!;
        }

        public void RemoveOrderItem(int orderId, int orderItemId)
        {
            var order = GetOrder(orderId);
            var orderItem = order.OrderItems.FirstOrDefault(p=>p.Id == orderItemId)!;
            order.OrderItems.Remove(orderItem);
         }

        public void UpdateOrderItem(OrderItem item)
        {
            dbContext.Update<OrderItem>(item); 
        }
    }
}
