
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using todowebapp.data.DataAccess;
using todowebapp.data.Models;

namespace todowebapp.data.Repositories
{

    public interface IToDoRepository
    {
        ToDoItem GetById(string id);
        IList<ToDoItem> GetToDoList();
        void Add(ToDoItem todo);
        void Delete(string id);
        bool Update(ToDoItem todo);
    }
    
    public class ToDoRepository : IToDoRepository
    {
        private readonly IToDoDbContext _toDoDbContext;
        public ToDoRepository(IToDoDbContext todoDbContext)
        {
            _toDoDbContext = todoDbContext;
        }

        public ToDoItem GetById(string id)
        {
            var todo = _toDoDbContext.ToDoList.AsQueryable().FirstOrDefault(t => t.Id == id);
            return todo;
        }

        public IList<ToDoItem> GetToDoList()
        {
            return IAsyncCursorSourceExtensions.ToList(_toDoDbContext.ToDoList.AsQueryable());
        }

        public void Add(ToDoItem todo)
        {
            _toDoDbContext.ToDoList.InsertOne(todo);
        }
        
        public void Delete(string id)
        {
            var deleteFilter = Builders<ToDoItem>.Filter.Eq("Id", id);
            _toDoDbContext.ToDoList.DeleteOne(deleteFilter);
        }

        public bool Update(ToDoItem todo)
        {
            var updateResult = _toDoDbContext.ToDoList.ReplaceOne(t => t.Id == todo.Id, todo);
            return updateResult.IsAcknowledged
                   && updateResult.ModifiedCount > 0;
        }
    }
    
    
}