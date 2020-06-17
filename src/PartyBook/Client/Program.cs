namespace PartyBook.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("PartyBook.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            //builder.Services.AddHttpClient("api")
            //    .AddHttpMessageHandler(sp =>
            //    {
            //        var handler = sp.GetService<AuthorizationMessageHandler>()
            //            .ConfigureHandler(
            //                authorizedUrls: new[] { "https://localhost:5002" },
            //                scopes: new[] { "weatherapi" });

            //        return handler;
            //    });


            //builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));

            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    builder.Configuration.Bind("oidc", options.ProviderOptions);
            //});

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("PartyBook.ServerAPI"));

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
