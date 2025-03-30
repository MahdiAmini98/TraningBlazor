using TraningAPIProject.Models.Entities;

namespace TraningAPIProject.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        List<Todo> GetAll();
        Todo? GetById(int id);
        void Add(Todo todo);
        void Update(int id, Todo todo);
        void PartialUpdate(int id, string title, bool? isCompleted);
        void Delete(int id);
    }
}
