using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;
using FoodDeliveryAPI.DataLayer.Repos;
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
        public async Task<ActionResult<bool>> AddNewRestaurant(CreateUpdateRestaurantDto restaurantDto)
        {
            return await _restaurantRepository.AddNewRestaurant(restaurantDto);
        }
        [HttpPut("UpdateRestaurant/{restaurantId}")]
        public async Task<ActionResult<bool>> UpdateRestaurant(int restaurantId, CreateUpdateRestaurantDto restaurantDto)
        {
            return await _restaurantRepository.UpdateRestaurant(restaurantId,restaurantDto);
        }

        [HttpGet("GetRestaurants")]
        public async Task<IEnumerable<RestaurantDto>> GetRestaurants()
        {
            return await _restaurantRepository.GetRestaurants();
        }

        [HttpGet("GetRestaurantById/{Id}")]
        public async Task<ActionResult<RestaurantDto>> GetRestaurantById(int Id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantById(Id);
            if(restaurant != null)
            {
                return restaurant;
            }
            return NotFound();
        }

        [HttpDelete("RemoveRestaurant/{Id}")]
        public async Task<ActionResult<bool>> RemoveRestaurant(int Id)
        {
            var restaurantRemoved =  await _restaurantRepository.RemoveRestaurant(Id);
            if (restaurantRemoved)
            {
                return Ok("Restaurantul a fost sters!");
            }

            return NotFound("Restaurantul nu a fost gasit!");
        }


        [HttpPost("AddMenuItemToRestaurant")]
        public async Task<ActionResult<bool>> AddNewMenuItem(MenuItemDto menuItemDto)
        {
            return await _menuItemRepository.AddNewMenuItem(menuItemDto);
        }

        [HttpDelete("RemoveMenuItem/{menuItemId}")]
        public async Task<ActionResult<bool>> RemoveMenuItem(int menuItemId)
        {
            var menuItemRemoved =  await _menuItemRepository.RemoveMenuItem(menuItemId);
            if (menuItemRemoved)
            {
                return Ok("Stergerea s-a realizat cu succes!");
            }

            return NotFound();
        }

        [HttpGet("GetMenuItem/{Id}")]
        public async Task<ActionResult<MenuItemDto>> GetMenuItemById(int Id)
        {
            var menuItem = await _menuItemRepository.GetMenuItemById(Id);
            return menuItem != null ? menuItem : NotFound();
        }

        [HttpPut("UpdateMenuItem/{menuItemId}")]
        public async Task<ActionResult<bool>> UpdateMenuItem(int menuItemId, MenuItemUpdatedDto menuItemDto)
        {
            var menuItemUpdated =  await _menuItemRepository.UpdateMenuItem(menuItemId,menuItemDto);
            if (menuItemUpdated)
            {
                return Ok("Updated succesufully!");
            }

            return NotFound();
        }

    }
}