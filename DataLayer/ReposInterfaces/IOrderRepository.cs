using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;

namespace FoodDeliveryAPI.DataLayer.ReposInterfaces
{
    public interface IOrderRepository
    {
       IEnumerable<Order> GetOrders();
        Order GetOrderById(int OrderId);
        void AddNewOrder(OrderDto order);
        void UpdateOrder(OrderDto order);
        void RemoveOrder(int OrderId); 
    }
}