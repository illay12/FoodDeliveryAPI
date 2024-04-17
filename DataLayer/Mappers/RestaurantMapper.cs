using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;

namespace FoodDeliveryAPI.DataLayer.Mappers
{
    public static class RestaurantMapper
    {
        public static RestaurantDto ToRestaurantDto(this Restaurant restaurant)
        {
            return new RestaurantDto
            {
                Name = restaurant.Name,
                Description = restaurant.Description,
                Address = restaurant.Address,
                PhoneNumber = restaurant.PhoneNumber,
                OpeningHours = restaurant.OpeningHours,
                DeliveryFee = restaurant.DeliveryFee,
                MenuItems = restaurant.MenuItems.toMenuItemDtos()
            };
        }

        public static Restaurant ToRestaurant(this RestaurantDto restaurantDto)
        {
            return new Restaurant
            {
                Name = restaurantDto.Name,
                Description = restaurantDto.Description,
                Address = restaurantDto.Address,
                PhoneNumber = restaurantDto.PhoneNumber,
                OpeningHours = restaurantDto.OpeningHours,
                DeliveryFee = restaurantDto.DeliveryFee,
                MenuItems = restaurantDto.MenuItems.toMenuItems()
            };
        }
    }
}