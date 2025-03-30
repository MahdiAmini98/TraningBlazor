using TraningBlazorProject.Client.Common.Services_Extensions;
using TraningBlazorProject.Client.Pages;
using TraningBlazorProject.Client.Pages._4._40_CascadingParameter;
using TraningBlazorProject.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();



//4.40- CascadingParameter
builder.Services.AddCascadingValue(p => new UserInfo() { Name = "Mahdi Amini" });
builder.Services.AddCascadingValue("Username", p => new UserInfo() { UserName = "MahdiAmini_98" });

//40.44 - virtualized
//builder.Services.AddScoped<ProductService>();

ServicesExtensions.AddCommonServices(builder.Services);


builder.Services.AddHttpClient();

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

app.Run();
