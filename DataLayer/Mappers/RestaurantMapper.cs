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

        public static Restaurant ToRestaurant(this CreateUpdateRestaurantDto resDto)
        {
            return new Restaurant
            {
                Name = resDto.Name,
                Description = resDto.Description,
                Address = resDto.Address,
                PhoneNumber = resDto.PhoneNumber,
                OpeningHours = resDto.OpeningHours,
                DeliveryFee = resDto.DeliveryFee,
            };
        }
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

        public static void Map(Restaurant restaurant,CreateUpdateRestaurantDto restaurantDto)
        {
            restaurant.Name = restaurantDto.Name;
            restaurant.Description = restaurantDto.Description;
            restaurant.Address = restaurantDto.Address;
            restaurant.PhoneNumber = restaurantDto.PhoneNumber;
            restaurant.OpeningHours = restaurantDto.OpeningHours;
            restaurant.DeliveryFee = restaurantDto.DeliveryFee;
        }
    }
}