using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalWebServer.Models;
using PortalWebServer.Repositories;
using PortalWebServer.Services.Interfaces;

namespace PortalWebServer
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("test")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> GetAllUsers()
        {
            return await Task.FromResult("Test");
        }
        

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            var user = _userService.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = _tokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }
    }
}