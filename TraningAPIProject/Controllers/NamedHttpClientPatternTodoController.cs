using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TraningAPIProject.Repositories.Interfaces;
using  TraningAPIProject.Models.Entities;


namespace TraningAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamedHttpClientPatternTodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public NamedHttpClientPatternTodoController(ITodoRepository repository)
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
            try
            {
                var existingTodo = _repository.GetById(id);
                if (existingTodo is null)
                {
                    return NotFound();
                }

                patchDoc.ApplyTo(existingTodo);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _repository.PartialUpdate(id, existingTodo.Title, existingTodo.IsCompleted);
                return NoContent();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }


            /*
              
             [
  {
    "op": "test",
    "path": "/title",
    "value": "خرید میوه"
  }
]
//add - remove -- replace - test  
             * */
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
