namespace PartyBook.MicroServices.Review
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PartyBook.Common.Infrastructure;
    using PartyBook.MicroServices.Review.Services;
    using PartyBook.ViewModels.Review;
    using PartyBook.MicroServices.Review.Data.Models;
    using PartyBook.MicroServices.Review.Data;
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
            //services.AddDbContext<ReviewDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection"),
            //        sqlOptions => sqlOptions
            //                 .EnableRetryOnFailure(
            //                     maxRetryCount: 10,
            //                     maxRetryDelay: TimeSpan.FromSeconds(30),
            //                     errorNumbersToAdd: null)));

            services.AddWebService<ReviewDbContext>(this.Configuration);
            services.AddMessaging<ReviewDbContext>(this.Configuration);
            services.AddTransient<IReviewService, ReviewService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app.UseWebService(env, typeof(Review).Assembly, typeof(ReviewCreateInputModel).Assembly)
                .Initialize<ReviewDbContext>();
    }
}
