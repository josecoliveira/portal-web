using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PortalWebServer.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("role")]
        public string Role { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("idColaborador")]
        public string IdColaborador { get; set; }
    }
}