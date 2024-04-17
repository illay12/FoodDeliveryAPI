using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace FoodDeliveryAPI.DataLayer.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                City = user.City,
            };
        }

        public static User ToUser(this UserDto userDto)
        {
            var passwordHasher = new PasswordHasher<string>();

            return new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = passwordHasher.HashPassword(userDto.Username,userDto.Password),
                City = userDto.City,
            };
        }
    }
}