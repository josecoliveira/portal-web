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

        public List<User> Get()
        {
            return _userRepository.Get();
        }

        public User Get(string email, string password)
        {
            return _userRepository.Get(email, password);
        }

        public List<User> GetUsersByIdColaborador(string idColaborador)
        {
            return _userRepository.GetUsersByIdColaborador(idColaborador);
        }
    }
}