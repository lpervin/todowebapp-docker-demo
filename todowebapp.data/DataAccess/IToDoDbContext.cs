using MongoDB.Driver;
using todowebapp.data.Models;

namespace todowebapp.data.DataAccess
{
    public interface IToDoDbContext
    {
       IMongoCollection<ToDoItem> ToDoList { get; }
    }
    
    
}