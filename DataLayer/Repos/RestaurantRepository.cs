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

        public async Task<bool> AddNewRestaurant(CreateUpdateRestaurantDto restaurntToAdd)
        {
            try
            {
                _context.Restaurants.Add(restaurntToAdd.ToRestaurant());
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex){
                return false;
            }
        }

        public async Task<RestaurantDto> GetRestaurantById(int restaurantId)
        {
            var res = await _context.Restaurants
            .Include(r => r.MenuItems)
            .FirstOrDefaultAsync(r => r.RestaurantId == restaurantId);
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

        public async Task<IEnumerable<RestaurantDto>> GetRestaurants()
        {
            return await _context.Restaurants
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
                .ToListAsync();
        }

        public async Task<bool> RemoveRestaurant(int restaurantId)
        {
            var checkResExists = _context.Restaurants.FirstOrDefault(r => r.RestaurantId == restaurantId);
            if (checkResExists != null)
            {
                var restaurantToRemove = await _context.Restaurants
                .Include(r => r.MenuItems)
                .FirstOrDefaultAsync(r => r.RestaurantId == restaurantId);
                _context.Restaurants.Remove(restaurantToRemove);
                await _context.SaveChangesAsync();
                return true;
            }
            
            return false;
            
        }

        public async Task<bool> UpdateRestaurant(int restaurantId,CreateUpdateRestaurantDto restaurantDto)
        {
            var restaurantToUpdate = _context.Restaurants.FirstOrDefault(r => r.RestaurantId == restaurantId);
            if(restaurantToUpdate != null)
            {
                RestaurantMapper.Map(restaurantToUpdate,restaurantDto);
                _context.Update(restaurantToUpdate);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}