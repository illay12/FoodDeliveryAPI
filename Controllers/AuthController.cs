using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FoodDeliveryAPI.DataLayer;
using FoodDeliveryAPI.DataLayer.Dtos;
using FoodDeliveryAPI.DataLayer.Dtos.UserDtos;
using FoodDeliveryAPI.DataLayer.Repos;
using FoodDeliveryAPI.DataLayer.ReposInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly FoodDeliveryDb _context;
        private readonly IUserRepository _userRepo;
        private readonly AuthHelper _authHelper;

        public AuthController(FoodDeliveryDb db, IUserRepository userRepo, AuthHelper authHelper)
        {
            _context = db;
            _userRepo = userRepo;
            _authHelper = authHelper;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<bool>> Register(UserForRegisterDto userForRegisterDto)
        {
            if (userForRegisterDto.Password == userForRegisterDto.PasswordConfirm)
            {
                var checkUserExists = await _userRepo.GetUserByEmail(userForRegisterDto.Email);

                if (checkUserExists == null)
                {
                    return await _userRepo.AddNewUser(userForRegisterDto);
                }

                throw new Exception("Failed to register user.");
            }

            throw new Exception("Passwords don't match!");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserForLoginDto userForLogin)
        {
            var userForConfirmation = await _userRepo.GetUserByEmail(userForLogin.Email);
            if (userForConfirmation != null)
            {
                byte[] passwordHash = _authHelper.GetPasswordHash(userForLogin.Password, userForConfirmation.PasswordSalt);

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (userForConfirmation.PasswordHash[i] != passwordHash[i])
                        return StatusCode(401, "Wrong Password!");
                }

                return Ok(new Dictionary<string, string> {
                    {"token", _authHelper.CreateToken(userForConfirmation)}
            });
            }
            throw new Exception("Failed to login");
        }

        [HttpPut("ChangePassword")]
        public async Task<ActionResult<bool>> ChangePassword(UserPasswordResetDto userForSetingPassword)
        {
            if(userForSetingPassword.Password == userForSetingPassword.PasswordConfirm)
            {
                //la claim e problema,trebuie sa cauti Id sau introduci cumva si email in claim
                var userToUpdate = new UserForLoginDto {
                    Email = User.FindFirst(ClaimTypes.Email).Value.ToString(),
                    Password = userForSetingPassword.Password
                };
                
                if(userToUpdate.Email != null)
                    return await _userRepo.UpdateUserPassword(userToUpdate);
                
                throw new Exception("Error!Something went wrong!");

            }
            
            throw new Exception("Passwords don't match!");
        }

    }
}