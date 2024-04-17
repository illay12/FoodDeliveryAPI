using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;
using FoodDeliveryAPI.DataLayer.ReposInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantRepository _restaurantRepository;
        private IMenuItemRepository _menuItemRepository;

        public RestaurantController(IMenuItemRepository menuItemRepository,IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
            _menuItemRepository = menuItemRepository;
        }

        [HttpPost("CreateRestaurant")]
        public void AddNewRestaurant(RestaurantDto restaurantDto)
        {
            _restaurantRepository.AddNewRestaurant(restaurantDto);
        }

        [HttpGet("GetRestaurants")]
        public IEnumerable<RestaurantDto> GetRestaurants()
        {
            return _restaurantRepository.GetRestaurants();
        }

        [HttpPost("AddMenuItemToRestaurant")]
        public void AddNewMenuItem(MenuItemDto menuItemDto)
        {
            _menuItemRepository.AddNewMenuItem(menuItemDto);
        }
    }
}