using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TraningBlazorProject.Client.Common.Services_Extensions;
using TraningBlazorProject.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
ServicesExtensions.AddCommonServices(builder.Services);
//برای ارسال داده یه api باید از HttpClient استفاده کنیم
builder.Services.AddScoped(sp => new HttpClient());

// 6.82 simple
//builder.Services.AddHttpClient("SmsApi", client =>
//{
//    client.BaseAddress = new Uri("https://sms.com/");
//});
// 6.82 add shared services
builder.Services.AddSharedServices();


await builder.Build().RunAsync();
