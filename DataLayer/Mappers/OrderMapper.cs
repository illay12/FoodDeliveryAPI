using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;

namespace FoodDeliveryAPI.DataLayer.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
                UserId = order.UserId,
            };
        }

        public static Order ToOrder(this OrderDto orderDto)
        {
            return new Order
            {
                UserId = orderDto.UserId,

            };
        }
    }
}