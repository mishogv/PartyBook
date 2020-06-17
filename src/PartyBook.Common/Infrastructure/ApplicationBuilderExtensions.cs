namespace PartyBook.Common.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using PartyBook.Services.Mapping;
    using PartyBook.ViewModels.NightClub;
    using System.Reflection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWebService(
            this IApplicationBuilder app,
            IWebHostEnvironment env, params Assembly[] assemblies)
        {
            AutoMapperConfig.RegisterMappings(assemblies);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app
                .UseCors(opt => 
                {
                    opt.AllowAnyOrigin();
                    opt.AllowAnyMethod();
                    opt.AllowAnyHeader();
                })
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                })
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapFallbackToFile("index.html");
                });

            return app;
        }

        //public static IApplicationBuilder Initialize(
        //    this IApplicationBuilder app)
        //{
        //    using var serviceScope = app.ApplicationServices.CreateScope();
        //    var serviceProvider = serviceScope.ServiceProvider;

        //    var db = serviceProvider.GetRequiredService<DbContext>();

        //    db.Database.Migrate();

        //    return app;
        //}
    }
}
