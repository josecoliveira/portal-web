using System.Collections.Generic;
using System.Linq;
using PortalWebServer.Models;
using PortalWebServer.Repositories.Interfaces;
using MongoDB.Driver;
using PortalWebServer.Models.Interfaces;

namespace PortalWebServer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }


        public List<User> Get()
        {
            return  _users.Find(user => true).ToList();
        }

        public User Get(string email, string password)
        {
            return _users.Find(user => user.Email == email && user.Password == password).FirstOrDefault();
        }

        public List<User> GetUsersByIdColaborador(string idColaborador)
        {
            return _users.Find(user => user.IdColaborador == idColaborador).ToList();
        }

        public void CreateUser(User user) {
            _users.InsertOne(user);
        }

        public User GetUserByEmail(string email)
        {
            return _users.Find(user => user.Email == email).First();
        }
    }
}