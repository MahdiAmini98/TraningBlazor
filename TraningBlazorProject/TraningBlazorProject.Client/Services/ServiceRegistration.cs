using TraningBlazorProject.Client.Services.TodoServices;

namespace TraningBlazorProject.Client.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddHttpClient("NamedHttpClientPatternTodo", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7215/api/NamedHttpClientPatternTodo/");
            });
            services.AddScoped<ITodoService, TodoService>();

            return services;
        }
    }
}
