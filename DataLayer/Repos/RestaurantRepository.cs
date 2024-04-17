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

        public void AddNewRestaurant(CreateRestaurantDto restaurntToAdd)
        {
            _context.Restaurants.Add(restaurntToAdd.ToRestaurant());
            _context.SaveChanges();
        }

        public RestaurantDto GetRestaurantById(int restaurantId)
        {
            var res = _context.Restaurants
            .Include(r => r.MenuItems)
            .FirstOrDefault(r => r.RestaurantId == restaurantId);
            if(res != null)
            return new RestaurantDto {
                Name = res.Name,
                Description = res.Description,
                Address = res.Address,
                PhoneNumber = res.PhoneNumber,
                OpeningHours = res.OpeningHours,
                DeliveryFee = res.DeliveryFee,
                MenuItems = res.MenuItems.toMenuItemDtos()

            };
            throw new Exception("Restaurant not found!");
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
                    MenuItems = r.MenuItems.ToList().toMenuItemDtos(),
                })
                .ToList();
        }

        public void RemoveRestaurant(int restaurantId)
        {
            var restaurantToRemove = _context.Restaurants
            .Include(r => r.MenuItems)
            .FirstOrDefault(r => r.RestaurantId == restaurantId);
            if (restaurantToRemove != null)
            {
                _context.Restaurants.Remove(restaurantToRemove);
                _context.SaveChanges();
            }
        }

        public void UpdateRestaurant(int updatedRestaurantId,RestaurantDto restaurant)
        {
            throw new NotImplementedException();
        }
    }
}