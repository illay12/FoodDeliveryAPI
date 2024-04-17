using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.DataLayer.ReposInterfaces
{
    public interface IRestaurantRepository
    {
        IEnumerable<RestaurantDto> GetRestaurants();
        RestaurantDto GetRestaurantById(int restaurantId);
        void AddNewRestaurant(CreateRestaurantDto restaurant);
        void UpdateRestaurant(int updatedRestaurantId,RestaurantDto restaurant);
        void RemoveRestaurant(int restaurantId); 
    }
}