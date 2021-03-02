using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PortalWebServer.Models;
using PortalWebServer.Repositories;
using PortalWebServer.Services.Interfaces;

namespace PortalWebServer
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [EnableCors("Policy")]
        public ActionResult<dynamic> Authenticate([FromBody]User model)
        {
            var user = _userService.Get(model.Email, model.Password);
            if (user == null)
            {
                return NotFound(new { message = "Invalid user or password" });
            }
            var token = _tokenService.GenerateToken(user);
            user.Password = "";
            user.Token = token;
            return user;
        }
        
        [HttpPost]
        [Route("colaborador")]
        [AllowAnonymous]
        [EnableCors("Policy")]
        public IActionResult CreateColaboradorUser([FromBody]User user)
        {
            user.Role = "Colaborador";
            _userService.CreateUser(user);
            return Ok();
        }

        [HttpGet]
        [Route("cliente")]
        [Authorize(Roles = "Colaborador")]
        [EnableCors("Policy")]
        public ActionResult<List<User>> GetUsersByIdColaborador()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _userService.GetUsersByIdColaborador(userId);
        }

        [HttpPost]
        [Route("cliente")]
        [Authorize(Roles = "Colaborador")]
        [EnableCors("Policy")]
        public IActionResult CreateClienteUser([FromBody]User user)
        {
            user.IdColaborador = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user.Role = "Cliente";
            _userService.CreateUser(user);
            return Ok();
        }


        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        [EnableCors("Policy")]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
        
    }
}