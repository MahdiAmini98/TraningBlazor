using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TraningBlazorProject.Client.Common.Services_Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
ServicesExtensions.AddCommonServices(builder.Services);
//برای ارسال داده یه api باید از HttpClient استفاده کنیم
builder.Services.AddScoped(sp => new HttpClient());
await builder.Build().RunAsync();
