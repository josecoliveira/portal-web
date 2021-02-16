using System.Collections.Generic;
using PortalWebServer.Models;

namespace PortalWebServer.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User Get(string username, string password);
    }
}