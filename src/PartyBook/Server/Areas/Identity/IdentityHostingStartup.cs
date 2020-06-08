using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(PartyBook.Server.Areas.Identity.IdentityHostingStartup))]
namespace PartyBook.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}