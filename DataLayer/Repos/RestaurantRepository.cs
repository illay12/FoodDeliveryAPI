using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;
using FoodDeliveryAPI.DataLayer.Mappers;
using FoodDeliveryAPI.DataLayer.ReposInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.DataLayer.Repos
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly FoodDeliveryDb _context;
        
        public RestaurantRepository(FoodDeliveryDb dbContext){
            _context = dbContext;
        }

        public void AddNewRestaurant(RestaurantDto restaurntToAdd)
        {
            _context.Restaurants.Add(restaurntToAdd.ToRestaurant());
            _context.SaveChanges();
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            return _context.Restaurants.FirstOrDefault(r => r.RestaurantId == restaurantId);
        }

        public IEnumerable<RestaurantDto> GetRestaurants()
        {
            return _context.Restaurants
                .Select(r => new RestaurantDto
                {
                    Name = r.Name,
                    Description = r.Description,
                    Address = r.Address,
                    PhoneNumber = r.PhoneNumber,
                    OpeningHours = r.OpeningHours,
                    DeliveryFee = r.DeliveryFee,
                    MenuItems = r.MenuItems.Where(m => m.RestaurantId == r.RestaurantId).ToList().toMenuItemDtos()
                })
                .ToList();
        }

        public void RemoveRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateRestaurant(int updatedRestaurantId,RestaurantDto restaurant)
        {
            throw new NotImplementedException();
        }
    }
}