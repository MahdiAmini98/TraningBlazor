using TraningBlazorProject.Client.Services.NamedHttpClientPattern.TodoServices;
using TraningBlazorProject.Client.Services.TypedHttpClientPattern.TodoServices;

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
            services.AddScoped<ITodoNamedService, TodoNamedService>();

            //6.83 typed http client pattern
            services.AddScoped<ITodoTypedService, TodoTypedService>();
            services.AddHttpClient<ITodoTypedService, TodoTypedService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7215/api/NamedHttpClientPatternTodo");
            });


            //8.
            return services;
        }
    }
}
