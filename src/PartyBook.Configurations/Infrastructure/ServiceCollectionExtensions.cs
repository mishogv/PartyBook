namespace PartyBook.Configurations.Infrastructure
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationSettings(
            this IServiceCollection services,
            IConfiguration configuration)
            => services.AddSingleton(new ApplicationSettings
                    {
                        NightClubAppUrl = configuration.GetSection("ApplicationSettings:NightClubAppUrl").Value,
                        ReviewAppUrl = configuration.GetSection("ApplicationSettings:ReviewAppUrl").Value,
                        ReservationsAppUrl = configuration.GetSection("ApplicationSettings:ReservationsAppUrl").Value,
                        StatisticsAppUrl = configuration.GetSection("ApplicationSettings:StatisticsAppUrl").Value,
                        Secret = configuration.GetSection("ApplicationSettings:Secret").Value
            });
    }
}
