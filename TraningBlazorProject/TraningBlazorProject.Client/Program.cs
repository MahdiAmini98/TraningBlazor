﻿using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TraningBlazorProject.Client.Common.Services_Extensions;
using TraningBlazorProject.Client.Pages._8._102_InMemoryStorage;
using TraningBlazorProject.Client.Services;
using TraningBlazorProject.Client.Services.ProductServices;

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

//6.85

builder.Services.AddHttpClient<IProductService, ClientProductService>(client =>
client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));


//8.102
builder.Services.AddSingleton<InMemoryStateContainer>();

await builder.Build().RunAsync();
