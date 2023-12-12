using Application.Clipboard;
using Application.Schemes;
using Html2Markdown;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApplication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<Converter>();
builder.Services.AddScoped<SchemeService>();
builder.Services.AddScoped<IClipboardService, ClipboardService>();
await builder.Build().RunAsync();