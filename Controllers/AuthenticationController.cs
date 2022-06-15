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
        [HttpPost("/login")]
        public Object login(LoginDTO userDTO)
        {
            if (UserServices.isExist(userDTO.name))
            {
                throw new Exception("user already exist!");
            }
            var HashNSalt = AuthenticationService.generateSaltAndPassword(userDTO.password);

            // TODO: userDTO içindekilerle birlikte HashNSalt veritabanına kaydedilecek ve kaydı user tipine çevirip kullanıcıya güvenli şekilde dönecek
            // userservice içindeki createuser kullanılıp ardından şifre oluşturulmalı ve kullanıcıya o kayıt dönülmeli
            return HashNSalt;
        }
        
        [HttpPost("/signin")]
        public void signin(SigninDTO userDTO)
        {

        }
    }
}
