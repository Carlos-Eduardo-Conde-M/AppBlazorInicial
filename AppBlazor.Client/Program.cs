using AppBlazor.Client;
using AppBlazor.Client.Servicios.RepresentantesSrevicios;
using AppBlazor.Client.Servicios.ClientesServicios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<RepresentantesServicio>();
builder.Services.AddScoped<SucursalRepresentanteServicio>();
builder.Services.AddScoped<DirectorServicio>();
builder.Services.AddScoped<ClienteServicio>();

await builder.Build().RunAsync();
