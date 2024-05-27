using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.DataLayer.Dtos.UserDtos
{
    public class UserPasswordResetDto
    {
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}