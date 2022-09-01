using CattleRanch.Web.Wasm;
using CattleRanch.Web.Wasm.Features.Animals.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("CattleRanchAPI", client => 
{
    client.BaseAddress = new Uri("https://localhost:5001/");
});
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IHttpAnimalService, HttpAnimalService>();

await builder.Build().RunAsync();
