using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Entities;
using FoodDeliveryAPI.DataLayer.ReposInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Mappers;

namespace FoodDeliveryAPI.DataLayer.Repos
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodDeliveryDb _context;
        
        public OrderRepository(FoodDeliveryDb dbContext){
            _context = dbContext;
        }
        
        public void AddNewOrder(OrderDto orderDto)
        {
            _context.Orders.Add(orderDto.ToOrder());
            _context.SaveChanges();
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == orderId); 
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public void RemoveOrder(int orderId)
        {
            Order orderToRemove = _context.Orders.Find(orderId);
            if (orderToRemove != null)
            {
                _context.Orders.Remove(orderToRemove);
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateOrder(OrderDto orderToUpdate)
        {
            //De implementat
        }
    }
}