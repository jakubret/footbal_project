using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BettingApp.Models
{
    public class Club
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Country { get; set; }
        
        public int Ranking { get; set; }
    }
}
