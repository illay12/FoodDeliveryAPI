using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Dtos.UserDtos;
using FoodDeliveryAPI.DataLayer.Entities;
using FoodDeliveryAPI.DataLayer.Mappers;
using FoodDeliveryAPI.DataLayer.ReposInterfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.DataLayer.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodDeliveryDb _context;
        private readonly AuthHelper _authHelper;
        
        public UserRepository(FoodDeliveryDb dbContext,AuthHelper authHelper){
            _context = dbContext;
            _authHelper = authHelper;
        }

        public async Task<bool> AddNewUser(UserForRegisterDto userToAddDto)
        {
           _authHelper.CreatePasswordHashAndSalt(userToAddDto.Password,out byte[] salt, out byte[] hash);
           if(salt != null && hash!= null)
           {
                var userToAdd = userToAddDto.ToUser();
                userToAdd.PasswordSalt = salt;
                userToAdd.PasswordHash = hash;
                await _context.Users.AddAsync(userToAdd);
                _context.SaveChanges();
                return true;
           }
           return false;
        }

        public async Task<bool> UpdateUserPassword(UserForLoginDto userForSetPassword)
        {
            _authHelper.CreatePasswordHashAndSalt(userForSetPassword.Password,out byte[] salt, out byte[] hash);
            var userToUpdate = await GetUserByEmail(userForSetPassword.Email);
            
            if(userToUpdate != null)
            {
                Console.WriteLine("ceva");   
                userToUpdate.PasswordSalt = salt;
                userToUpdate.PasswordHash = hash;
                await _context.SaveChangesAsync();
                return true;

            }
            return false;
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(UserForUpdateDto userToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}