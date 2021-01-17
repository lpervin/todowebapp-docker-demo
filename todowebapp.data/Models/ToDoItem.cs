using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace todowebapp.data.Models
{
     public class ToDoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public int Key { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}