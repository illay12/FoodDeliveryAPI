using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;
using FoodDeliveryAPI.DataLayer.Mappers;
using FoodDeliveryAPI.DataLayer.ReposInterfaces;

namespace FoodDeliveryAPI.DataLayer.Repos
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly FoodDeliveryDb _context;
        
        public MenuItemRepository(FoodDeliveryDb dbContext){
            _context = dbContext;
        }
        
        public void AddNewMenuItem(MenuItemDto menuItemDto)
        {
            _context.MenuItems.Add(menuItemDto.ToMenuItem());
            _context.SaveChanges();
        }

        public MenuItem GetMenuItemById(int menuItemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            throw new NotImplementedException();
        }

        public void RemoveMenuItem(int menuItemId)
        {
            var menuItemToRemove = _context.MenuItems.FirstOrDefault(m => m.Id == menuItemId);
            if(menuItemToRemove != null)
            {
                _context.MenuItems.Remove(menuItemToRemove);
                _context.SaveChanges();
            }

        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateMenuItem(MenuItemDto menuItem)
        {
            throw new NotImplementedException();
        }
    }
}