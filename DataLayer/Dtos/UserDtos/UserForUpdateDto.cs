using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.DataLayer.Dtos
{
    public class UserForUpdateDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string City {get; set;}
    }
}