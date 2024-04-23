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
        Task<MenuItemDto> GetMenuItemById(int MenuItemId);
        Task<bool> AddNewMenuItem(MenuItemDto menuItem);
        Task<bool> UpdateMenuItem(int menutItemId, MenuItemUpdatedDto menuItemToUpdate);
        Task<bool> RemoveMenuItem(int MenuItemId);
    }
}