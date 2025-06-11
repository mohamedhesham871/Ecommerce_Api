using AbstractionServices;
using Microsoft.Extensions.DependencyInjection;
using Services.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FactorServices
{
    public static class AddWebServicesFactorization
    {
        public static IServiceCollection AddWebServicesRegistrations(this IServiceCollection services )
        {
            services.AddAutoMapper(typeof(ProductProfile).Assembly);
            services.AddScoped<IServicesManager, ServicesManager>();
            return services;
        }
    }
}
