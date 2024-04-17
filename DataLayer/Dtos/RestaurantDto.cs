using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Entities;

namespace FoodDeliveryAPI.DataLayer.Dtos
{
    public class RestaurantDto
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string OpeningHours { get; set; } = "";
        public decimal DeliveryFee {get;set;}
        public ICollection<MenuItemDto>? MenuItems { get; set; } 
    }
}