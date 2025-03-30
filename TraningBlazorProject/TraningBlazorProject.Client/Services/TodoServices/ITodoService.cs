using Microsoft.AspNetCore.JsonPatch;
using System.Net.Http.Json;

namespace TraningBlazorProject.Client.Services.TodoServices
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllTodosAsync();
        Task<Todo> GetTodoByIdAsync(int id);
        Task<Todo> AddTodoAsync(Todo newTodo);
        Task UpdateTodoAsync(int id, Todo updatedTodo);
        Task PartialUpdateTodoAsync(int id, JsonPatchDocument<Todo> patchDoc);
        Task DeleteTodoAsync(int id);
    }


    public class TodoService : ITodoService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public TodoService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Todo> AddTodoAsync(Todo newTodo)
        {
            var client = httpClientFactory.CreateClient("NamedHttpClientPatternTodo");
            var response = await client.PostAsJsonAsync("", newTodo);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Todo>();
        }

        public async Task DeleteTodoAsync(int id)
        {
            var client = httpClientFactory.CreateClient("NamedHttpClientPatternTodo");
            var response = await client.DeleteAsync($"{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Todo>> GetAllTodosAsync()
        {
            var client = httpClientFactory.CreateClient("NamedHttpClientPatternTodo");
            return await client.GetFromJsonAsync<List<Todo>>("");
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            var client = httpClientFactory.CreateClient("NamedHttpClientPatternTodo");
            return await client.GetFromJsonAsync<Todo>($"{id}");
        }

        public async Task PartialUpdateTodoAsync(int id, JsonPatchDocument<Todo> patchDoc)
        {
            var client = httpClientFactory.CreateClient("NamedHttpClientPatternTodo");
            var response = await client.PatchAsJsonAsync($"{id}", patchDoc.Operations);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateTodoAsync(int id, Todo updatedTodo)
        {
            var client = httpClientFactory.CreateClient("NamedHttpClientPatternTodo");
            var response = await client.PutAsJsonAsync($"{id}", updatedTodo);
            response.EnsureSuccessStatusCode();
        }
    }

    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
