using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperExample.DTOs.Authentication;
using DapperExample.Models;
using DapperExample.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private AuthenticationService _authService = new AuthenticationService();
        private UserServices _userService= new UserServices();

        [HttpPost("/login")]
        public object login(LoginDTO userDTO)
        {

            User user = _userService.getUserByUsername(userDTO.name);
            if (!_authService.authenticatePassword(userDTO.password, user.password_hash, user.password_salt))
            {
                throw new Exception("User not found or password is incorrect!");
            }

            return new { user };
        }

        [HttpPost("/signin")]
        public User signin(SigninDTO userDTO)
        {
            // TODO: Body validation
            if (_userService.isExist(userDTO.name))
            {
                throw new Exception("user already exist!");
            }

            User user = _userService.createUser(userDTO.name, false, userDTO.password);
            return user;
        }
    }
}
