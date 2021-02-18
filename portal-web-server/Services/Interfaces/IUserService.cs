using System.Collections.Generic;
using PortalWebServer.Models;

namespace PortalWebServer.Services.Interfaces
{
    public interface IUserService
    {
        List<User> Get();
        User Get(string email, string password);
        List<User> GetUsersByIdColaborador(string idColaborador);
    }
}