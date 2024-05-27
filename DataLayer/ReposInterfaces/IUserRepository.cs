using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Dtos.UserDtos;
using FoodDeliveryAPI.DataLayer.Entities;

namespace FoodDeliveryAPI.DataLayer.ReposInterfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<bool> UpdateUserPassword(UserForLoginDto userForSetPassword);
        Task<User> GetUserById(int userId);
        Task<bool> AddNewUser(UserForRegisterDto userToAdd);
        Task<bool> UpdateUser(UserForUpdateDto userToUpdate);
        Task<bool> RemoveUser(int userId);
        Task<User> GetUserByEmail(string email);
    }
}