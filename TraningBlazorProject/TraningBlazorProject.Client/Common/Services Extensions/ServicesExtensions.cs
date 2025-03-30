using TraningBlazorProject.Client.Services;

namespace TraningBlazorProject.Client.Common.Services_Extensions
{
    public static class ServicesExtensions
    {
        public static void AddCommonServices(IServiceCollection services)
        {
            services.AddScoped<ProductService>();
        }
    }
}
