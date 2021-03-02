using System.Collections.Generic;
using PortalWebServer.Models;

namespace PortalWebServer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> Get();
        User Get(string email, string password);
        List<User> GetUsersByIdColaborador(string idColaborador);
        void CreateUser(User user);
        User GetUserByEmail(string email);
    }
}