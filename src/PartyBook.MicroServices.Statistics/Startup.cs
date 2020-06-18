namespace PartyBook.MicroServices.Statistics
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PartyBook.Common.Infrastructure;
    using PartyBook.MicroServices.Statistics.Data;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StatisticsDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddWebService();
        }

        //TODO : Register Mappings
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.UseWebService(env, null);
    }
}
