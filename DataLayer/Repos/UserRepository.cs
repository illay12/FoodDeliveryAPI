using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Entities;
using FoodDeliveryAPI.DataLayer.Mappers;
using FoodDeliveryAPI.DataLayer.ReposInterfaces;

namespace FoodDeliveryAPI.DataLayer.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodDeliveryDb _context;
        
        public UserRepository(FoodDeliveryDb dbContext){
            _context = dbContext;
        }

        public void AddNewUser(UserDto userToAdd)
        {
            _context.Users.Add(userToAdd.ToUser());
            _context.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void RemoveUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserDto userToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}