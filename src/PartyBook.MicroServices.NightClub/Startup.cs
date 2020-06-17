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

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NightClubDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddWebService();

            services.AddTransient<IBookService, BookService>();
            services.AddTransient<INightClubService, NightClubService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IEventService, EventService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.UseWebService(env);
    }
}
