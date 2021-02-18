using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public ActionResult<dynamic> Authenticate([FromBody]User model)
        {
            var user = _userService.Get(model.Email, model.Password);

            if (user == null)
                return NotFound(new { message = "Invalid user or password" });

            var token = _tokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("clientes")]
        [Authorize(Roles = "Colaborador")]
        public ActionResult<List<User>> GetUsersByIdColaborador()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _userService.GetUsersByIdColaborador(userId);
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
        
        }
}