using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;
using FoodDeliveryAPI.DataLayer.Mappers;
using FoodDeliveryAPI.DataLayer.ReposInterfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.DataLayer.Repos
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly FoodDeliveryDb _context;
        
        public MenuItemRepository(FoodDeliveryDb dbContext){
            _context = dbContext;
        }
        
        public async Task<bool> AddNewMenuItem(MenuItemDto menuItemDto)
        {
            try{   
                _context.MenuItems.Add(menuItemDto.ToMenuItem());
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex){
                return false;
            }
        }

        public async Task<MenuItemDto> GetMenuItemById(int menuItemId)
        {
            var menuItem =  await _context.MenuItems.FirstOrDefaultAsync(m => m.Id == menuItemId);
            if (menuItem != null)
            {
                return menuItem.ToMenuItemDto();
            }

            return null;
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveMenuItem(int menuItemId)
        {
            var menuItemToRemove = _context.MenuItems.FirstOrDefault(m => m.Id == menuItemId);
            if(menuItemToRemove != null)
            {
                _context.MenuItems.Remove(menuItemToRemove);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<bool> UpdateMenuItem(int menuItemId, MenuItemUpdatedDto menuItemDto)
        {
            var menuItemToUpdate = _context.MenuItems.FirstOrDefault(m => m.Id == menuItemId);
            if(menuItemToUpdate != null)
            {
                MenuItemMapper.Map(menuItemToUpdate, menuItemDto);
                _context.Update(menuItemToUpdate);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}