using CryptoChat.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Nethereum.Web3;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HubConnectionBuilder()
			.WithUrl(builder.HostEnvironment.BaseAddress + "chathub")
			.Build());
builder.Services.AddScoped(sp => new Storage(builder.HostEnvironment.BaseAddress + "chathub"));
builder.Services.AddScoped(sp => new Web3());

await builder.Build().RunAsync();
