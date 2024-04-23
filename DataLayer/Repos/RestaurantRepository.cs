using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;
using FoodDeliveryAPI.DataLayer.Mappers;
using FoodDeliveryAPI.DataLayer.ReposInterfaces;
using Microsoft.AspNetCore.Diagnostics;
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

        public IActionResult AddNewRestaurant(CreateUpdateRestaurantDto restaurntToAdd)
        {
            try
            {
            _context.Restaurants.Add(restaurntToAdd.ToRestaurant());
            _context.SaveChanges();
            return new OkResult();
            }
            catch(Exception ex)
            {
                throw new Exception("Something didn't work while trying to add the resaturant!");
            }
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
            return null;

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

        public IActionResult RemoveRestaurant(int restaurantId)
        {
            var checkResExists = _context.Restaurants.FirstOrDefault(r => r.RestaurantId == restaurantId);
            if (checkResExists != null)
            {
                var restaurantToRemove = _context.Restaurants
                .Include(r => r.MenuItems)
                .FirstOrDefault(r => r.RestaurantId == restaurantId);
                _context.Restaurants.Remove(restaurantToRemove);
                _context.SaveChanges();
                return new OkResult();
            }
            return new NotFoundResult();
            
        }

        public IActionResult UpdateRestaurant(int restaurantId,CreateUpdateRestaurantDto restaurantDto)
        {
            var restaurantToUpdate = _context.Restaurants.FirstOrDefault(r => r.RestaurantId == restaurantId);
            if(restaurantToUpdate != null)
            {
                RestaurantMapper.Map(restaurantToUpdate,restaurantDto);
                _context.Update(restaurantToUpdate);
                _context.SaveChanges();
                return new OkResult();
            }

            return new NotFoundResult();
        }
    }
}