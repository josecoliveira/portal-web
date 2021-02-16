using System.Collections.Generic;
using PortalWebServer.Models;
using PortalWebServer.Services.Interfaces;
using PortalWebServer.Repositories.Interfaces;

namespace PortalWebServer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = _userRepository.GetAllUsers();
            return users;
        }

        public User Get(string username, string passoword)
        {
            User user = _userRepository.Get(username, passoword);
            return user;
        }
    }
}