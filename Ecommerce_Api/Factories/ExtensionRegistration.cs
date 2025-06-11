using Domain.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Api.Factories
{
    public static class ExtensionRegistration
    {
        public static IServiceCollection WebResgistraion(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            { options.InvalidModelStateResponseFactory = ApiBehavior.ConfigureApiBehavior; });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
        public static async Task SeedData(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                await dbInitializer.InitializeAsync();
            }
        }

    }
}
