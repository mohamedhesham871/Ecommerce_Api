using Domain.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data.Contexts;
using Persistence.Repo;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.FactorRegistration
{
    public static class AddRepoAndDataRegistration
    {
        public static IServiceCollection AddRegistrationForDataAndRepo(this IServiceCollection services , IConfiguration config)
        {
             services.AddDbContext<StoreDbContext>(options =>
             options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

             services.AddScoped<IDbInitializer, DbInitializer>();
             services.AddScoped<IUnitOfwork, UnitOfWork>();
            services.AddScoped<IBasketRepo, BasketRepo>();
            services.AddScoped<ICashRepository, CashRepository>();
            services.AddSingleton<IConnectionMultiplexer>((serviceProvider) => {
                return ConnectionMultiplexer.Connect(config.GetConnectionString("Redis")!);
            });
            return services;
        }
        //Function to Seed Data
       

    }
}
