using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todowebapp.data.Models;
using todowebapp.data.Repositories;

namespace todowebapp.ui.Controllers
{
    public class ToDosController : Controller
    {
        private readonly IToDoRepository _repository;

        public ToDosController(IToDoRepository repository)
        {
            _repository = repository;
        }

        // GET
        public IActionResult Index()
        {
            var todos = _repository.GetToDoList();
            return View(todos.ToList());
        }

        public IActionResult Details(string id)
        {
            var todo = _repository.GetById(id);
            return View(todo);
        }

        public IActionResult Edit(string id)
        {
            var todo = _repository.GetById(id);
            todo.IsCompleted = !todo.IsCompleted;
            _repository.Update(todo);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
             _repository.Delete(id);
             return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }
        
        public IActionResult AddItem(ToDoItem todo)
        {
            _repository.Add(todo);
            return RedirectToAction("Index");
        }
    }
}