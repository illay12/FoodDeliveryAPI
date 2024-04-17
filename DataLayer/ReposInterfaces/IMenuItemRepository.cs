using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;

namespace FoodDeliveryAPI.DataLayer.ReposInterfaces
{
    public interface IMenuItemRepository
    {
        IEnumerable<MenuItem> GetMenuItems();
        MenuItem GetMenuItemById(int MenuItemId);
        void AddNewMenuItem(MenuItemDto menuItem);
        void UpdateMenuItem(MenuItemDto menuItem);
        void RemoveMenuItem(int MenuItemId);
        void Save(); 
    }
}