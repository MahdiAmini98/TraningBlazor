using System.Xml.Linq;
using TraningAPIProject.Models.Entities;
using TraningAPIProject.Repositories.Interfaces;

namespace TraningAPIProject.Repositories.Services
{
    public class TodoRepository : ITodoRepository
    {
        private readonly List<Todo> _todos = new List<Todo>
        {

          new Todo
           {
             Id = 1,
             IsCompleted = false,
             Title = "پیاده‌سازی یک API"
           },

           new Todo
           {
             Id = 2,
             IsCompleted = true,
             Title = "رفع خطاهای برنامه"
           }
        };

        public List<Todo> GetAll()
        {
            return _todos;
        }

        public Todo? GetById(int id)
        {
            return _todos.FirstOrDefault(todo => todo.Id == id);
        }

        public void Add(Todo todo)
        {
            todo.Id = _todos.Count > 0 ? _todos.Max(t => t.Id) + 1 : 1;
            _todos.Add(todo);
        }

        public void Update(int id, Todo updatedTodo)
        {
            var existingTodo = GetById(id);
            if (existingTodo is not null)
            {
                existingTodo.Title = updatedTodo.Title;
                existingTodo.IsCompleted = updatedTodo.IsCompleted;
            }
        }

        public void PartialUpdate(int id, string title, bool? isCompleted)
        {
            var existingTodo = GetById(id);
            if (existingTodo is not null)
            {
                if (title is not null) existingTodo.Title = title;
                if (isCompleted.HasValue) existingTodo.IsCompleted = isCompleted.Value;
            }
        }

        public void Delete(int id)
        {
            var todo = GetById(id);
            if (todo is not null)
            {
                _todos.Remove(todo);
            }
        }
    }
}
