using MongoDB.Bson;
using MongoDB.Driver;
using todowebapp.data.Models;
using todowebapp.data.Configs;

namespace todowebapp.data.DataAccess
{
    public class ToDoDbContext : IToDoDbContext
    {
        private readonly IMongoDatabase _db;
        private readonly MongoDBConfig _configs;
        public ToDoDbContext(MongoDBConfig config)
        {
            _configs = config;
            var client = new MongoClient(_configs.ConnectionString);
            _db = client.GetDatabase(_configs.Database);
            ToDoDataContextDataSeed.SeedCollection(_db, _configs.CollectionName);            
        }

        public IMongoCollection<ToDoItem> ToDoList => _db.GetCollection<ToDoItem>(_configs.CollectionName);

    }

    public class ToDoDataContextDataSeed
    {
        public static void SeedCollection(IMongoDatabase mongoDb, string collectionName)
        {
            //check if exist
            var filter = new BsonDocument("name", collectionName);
            var collections = mongoDb.ListCollections(new ListCollectionsOptions() { Filter =  filter});
            if (collections.Any())
                return;
            
            mongoDb.CreateCollection(collectionName);
            
            // if (mongoDb.GetCollection<ToDoItem>(collectionName).)
        }
    }
}