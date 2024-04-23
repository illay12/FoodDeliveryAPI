using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;

namespace FoodDeliveryAPI.DataLayer.Mappers
{
    public static class MenuItemMapper
    {
        public static MenuItemDto ToMenuItemDto(this MenuItem menuItem)
        {
            return new MenuItemDto
            {
                RestaurantId = menuItem.RestaurantId,
                Name = menuItem.Name,
                Description = menuItem.Description,
                Price = menuItem.Price,
                Category = menuItem.Category
            };
        }

        public static MenuItem ToMenuItem(this MenuItemDto menuItemDto)
        {
            return new MenuItem
            {
                RestaurantId = menuItemDto.RestaurantId,
                Name = menuItemDto.Name,
                Description = menuItemDto.Description,
                Price = menuItemDto.Price,
                Category = menuItemDto.Category

            };
        }

        public static ICollection<MenuItemDto> toMenuItemDtos (this ICollection<MenuItem> menuItems)
        {
            ICollection<MenuItemDto> list = new List<MenuItemDto>();
            if(menuItems != null){
                foreach (MenuItem item in menuItems)
                {
                    list.Add(item.ToMenuItemDto());
                }
            }
            return list;
        }

        public static ICollection<MenuItem> toMenuItems (this ICollection<MenuItemDto> menuItemDtos)
        {
            ICollection<MenuItem> list = new List<MenuItem>();
            foreach (MenuItemDto item in menuItemDtos)
            {
                list.Add(item.ToMenuItem());
            }

            return list;
        }

        public static void Map(MenuItem menuItem, MenuItemUpdatedDto menuItemDto)
        {
                menuItem.Name = menuItemDto.Name;
                menuItem.Description = menuItemDto.Description;
                menuItem.Price = menuItemDto.Price;
                menuItem.Category = menuItemDto.Category;
        }
    }
}