using ArtStore.Blazor;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ArtStore.Blazor.Interfaces;
using ArtStore.Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7262") });
builder.Services.AddMudServices();

builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
