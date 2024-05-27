using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BettingApp.Models
{
    public class Pot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
            
        public int Number { get; set; }
        
        public List<Club> Clubs { get; set; }
    }
}
