namespace PartyBook.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("PartyBook.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler(sp => 
                {
                    var handler = sp.GetService<AuthorizationMessageHandler>()
                    .ConfigureHandler(
                        authorizedUrls: new[] { "https://localhost:5002", "https://localhost:5003" });
                    return handler;
                });

            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("PartyBook.ServerAPI"));

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
