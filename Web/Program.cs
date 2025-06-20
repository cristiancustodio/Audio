using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web;
using Web.Configuration;
using Web.Services;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();
var supabaseOptions = builder.Configuration
    .GetSection(Web.Configuration.SupabaseOptions.SectionName)
    .Get<Web.Configuration.SupabaseOptions>();
builder.Services.AddScoped(sp => new Web.Services.SupabaseService(supabaseOptions));

await builder.Build().RunAsync();
