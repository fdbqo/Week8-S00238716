using Blazored.Toast;
using DataServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RAD30223Week8BlazorAppS00238716;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// staandard scoped http client service replaced with custom service below

//builder.Services.AddHttpClient<IProductService, ProductService>(client => 
//                client.BaseAddress = new Uri("https://localhost:7218/"));

// needed to add this for grn routes
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7218/")
});

builder.Services.AddHttpClient<IHttpClientService, HttpClientService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7218/");
});
builder.Services.AddBlazoredToast();
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddSingleton<AppState>();
//builder.Services.AddScoped<ToastService>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var _localservice = scope.ServiceProvider.GetRequiredService<ILocalStorageService>();
    var _appState = scope.ServiceProvider.GetRequiredService<AppState>();
    // Clear the Token if set
    await _localservice.RemoveItem("token");
    // set loged out
    _appState.LoggedIn = false;
}
await app.RunAsync();
