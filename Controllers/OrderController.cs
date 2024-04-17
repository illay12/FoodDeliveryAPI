using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;
using FoodDeliveryAPI.DataLayer.Repos;
using FoodDeliveryAPI.DataLayer.ReposInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("GetOrders")]
        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        [HttpGet("GetSingleOrder/{id}")]
        public IActionResult GetSingleOrder(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if(order != null)
                return Ok();
            return NotFound("Order not found it was.");
        }

        [HttpPost("AddOrder")]
        public void AddNewOrder(OrderDto orderToAdd)
        {
            _orderRepository.AddNewOrder(orderToAdd);   
        }
}