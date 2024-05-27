using BettingApp.Models;
using MongoDB.Driver;

namespace BettingApp.Data
{
    public class BettingContext
    {
        private readonly IMongoDatabase _database;

        public BettingContext(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Club> Clubs => _database.GetCollection<Club>("Clubs");
        public IMongoCollection<Pot> Pots => _database.GetCollection<Pot>("Pots");
    }
}
