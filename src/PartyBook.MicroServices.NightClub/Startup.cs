namespace PartyBook.MicroServices.NightClub
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PartyBook.Common.Infrastructure;
    using PartyBook.MicroServices.NightClub.Data;
    using PartyBook.MicroServices.NightClub.Services;
    using PartyBook.MicroServices.NightClub.Data.Models;
    using PartyBook.ViewModels.NightClub;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NightClubDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddWebService();

            services.AddTransient<INightClubService, NightClubService>();
            services.AddTransient<IEventService, EventService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.UseWebService(env, typeof(NightClub).Assembly, typeof(NightClubCreateInputModel).Assembly);
    }
}
