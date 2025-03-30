using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TraningAPIProject.Models.Entities;
using TraningAPIProject.Repositories.Interfaces;

namespace TraningAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _repository.GetAll();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _repository.GetById(id);
            if (todo is null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public IActionResult Add(Todo todo)
        {
            _repository.Add(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Todo todo)
        {
            if (_repository.GetById(id) is null)
            {
                return NotFound();
            }
            _repository.Update(id, todo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdate(int id, [FromBody] JsonPatchDocument<Todo> patchDoc)
        {
            var existingTodo = _repository.GetById(id);
            if (existingTodo is null)
            {
                return NotFound();
            }

            var updatedTodo = new Todo
            {
                Id = existingTodo.Id,
                Title = existingTodo.Title,
                IsCompleted = existingTodo.IsCompleted
            };

            patchDoc.ApplyTo(updatedTodo);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.PartialUpdate(id, updatedTodo.Title, updatedTodo.IsCompleted);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.GetById(id) is null)
            {
                return NotFound();
            }
            _repository.Delete(id);
            return NoContent();
        }
    }
}
