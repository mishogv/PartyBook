namespace PartyBook.Common.Infrastructure
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebService(
            this IServiceCollection services)
        {
            services
                .AddTokenAuthentication()
                .AddSwagger()
                .AddControllers();

            return services;
        }

        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://localhost:5000";
                    options.Audience = "PartyBook.ServerAPI";
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {   
                        NameClaimType = "name"
                    };
                });

            return services;
        }

        public static IServiceCollection AddSwagger(
            this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "My PartyBook API",
                        Version = "v1"
                    });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}

                    }
                });
            });

            return services;
        }
    }
}
