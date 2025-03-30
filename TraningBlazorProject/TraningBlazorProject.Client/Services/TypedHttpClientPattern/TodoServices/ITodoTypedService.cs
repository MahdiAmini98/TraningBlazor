using System.Net.Http.Json;
using TraningBlazorProject.Client.Services.NamedHttpClientPattern.TodoServices;

namespace TraningBlazorProject.Client.Services.TypedHttpClientPattern.TodoServices
{
    public interface ITodoTypedService
    {
        Task<List<Todo>> GetTodosAsync();
        Task AddTodoAsync(Todo newTodo);
    }
    public class TodoTypedService : ITodoTypedService
    {
        private readonly HttpClient _httpClient;

        public TodoTypedService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddTodoAsync(Todo newTodo)
        {
            var response = await _httpClient.PostAsJsonAsync("", newTodo);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }
        }

        public async Task<List<Todo>> GetTodosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Todo>>("");
        }
    }
}
