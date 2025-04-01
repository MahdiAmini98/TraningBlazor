using TraningBlazorProject.Client.Common.Services_Extensions;
using TraningBlazorProject.Client.Pages;
using TraningBlazorProject.Client.Pages._4._40_CascadingParameter;
using TraningBlazorProject.Components;
using TraningBlazorProject.Client.Services;
using TraningBlazorProject.Repositories;
using TraningBlazorProject.Client.Services.ProductServices;
using TraningBlazorProject.Services;
using TraningBlazorProject.Client.Pages._8._102_InMemoryStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents().AddCircuitOptions(options =>
    {
        options.DetailedErrors = true;
    }).AddInteractiveWebAssemblyComponents();



//4.40- CascadingParameter
builder.Services.AddCascadingValue(p => new UserInfo() { Name = "Mahdi Amini" });
builder.Services.AddCascadingValue("Username", p => new UserInfo() { UserName = "MahdiAmini_98" });

//40.44 - virtualized
//builder.Services.AddScoped<ProductService>();

ServicesExtensions.AddCommonServices(builder.Services);


// 6.82 add shared services
builder.Services.AddSharedServices();



//6.85- add service
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ServerProductService>();


//اضافه کرد http client
builder.Services.AddHttpClient();




//8.102
builder.Services.AddScoped<InMemoryStateContainer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(TraningBlazorProject.Client._Imports).Assembly).AddAdditionalAssemblies(typeof(TraningRCLProject._Imports).Assembly);



//6.85

app.MapGet("/api/products", (IProductRepository repository) =>
{
    return repository.GetProducts();

}).WithName("GetProducts");


app.Run();
