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
        Task<IEnumerable<RestaurantDto>> GetRestaurants();
        Task<RestaurantDto> GetRestaurantById(int restaurantId);
        Task<bool> AddNewRestaurant(CreateUpdateRestaurantDto restaurant);
        Task<bool> UpdateRestaurant(int updatedRestaurantId,CreateUpdateRestaurantDto restaurant);
        Task<bool> RemoveRestaurant(int restaurantId); 
    }
}