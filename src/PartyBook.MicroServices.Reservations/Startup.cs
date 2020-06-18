namespace PartyBook.MicroServices.Reservations
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PartyBook.Common.Infrastructure;
    using PartyBook.MicroServices.Reservations.Data;
    using PartyBook.MicroServices.Reservations.Data.Models;
    using PartyBook.MicroServices.Reservations.Services;
    using PartyBook.ViewModels.Reservation;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ReservationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddWebService();

            services.AddTransient<IReservationService, ReservationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.UseWebService(env, typeof(Reservation).Assembly, typeof(ReservationtCreateInputModel).Assembly);
    }
}
