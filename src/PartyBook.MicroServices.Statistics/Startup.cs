namespace PartyBook.MicroServices.Statistics
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PartyBook.Common.Infrastructure;
    using PartyBook.MicroServices.Statistics.Data;
    using PartyBook.MicroServices.Statistics.Messages;
    using PartyBook.MicroServices.Statistics.Services;
    using System;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebService<StatisticsDbContext>(this.Configuration);
            services.AddMessaging<StatisticsDbContext>(this.Configuration, typeof(ReviewCreatedConsumer));
            services.AddTransient<IStatisticsService, StatisticsService>();
        }

        //TODO : Register Mappings
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.UseWebService(env, null).Initialize<StatisticsDbContext>();
    }
}
