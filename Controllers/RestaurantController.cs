using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;
using FoodDeliveryAPI.DataLayer.ReposInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public void AddNewRestaurant(CreateRestaurantDto restaurantDto)
        {
            _restaurantRepository.AddNewRestaurant(restaurantDto);
        }

        [HttpGet("GetRestaurants")]
        public IEnumerable<RestaurantDto> GetRestaurants()
        {
            return _restaurantRepository.GetRestaurants();
        }

        [HttpGet("GetRestaurantById/{Id}")]
        public IActionResult GetRestaurantById(int Id)
        {
            var restaurant = _restaurantRepository.GetRestaurantById(Id);
            if(restaurant != null)
            {
                return Ok(restaurant);
            }
            return NotFound("Restaurant was not found");
        }

        [HttpDelete("RemoveRestaurant{Id}")]
        public void RemoveRestaurant(int Id)
        {
             _restaurantRepository.RemoveRestaurant(Id);
        }


        [HttpPost("AddMenuItemToRestaurant")]
        public void AddNewMenuItem(MenuItemDto menuItemDto)
        {
            _menuItemRepository.AddNewMenuItem(menuItemDto);
        }
    }
}