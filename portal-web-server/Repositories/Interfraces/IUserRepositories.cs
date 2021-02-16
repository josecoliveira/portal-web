using System.Collections.Generic;
using PortalWebServer.Models;

namespace PortalWebServer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Get(string username, string password);
        List<User> GetAllUsers();
    }
}