using AbstractionServices;
using Domain.Contract;
using Ecommerce_Api.Factories;
using Ecommerce_Api.MiddelWare;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Options;
using Persistence;
using Persistence.Data.Contexts;
using Persistence.FactorRegistration;
using Services;
using Services.FactorServices;
using Services.MappingProfile;
using Shared;

namespace Ecommerce_Api
{
    public class Program
    {
        public static   async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Services
          
            builder.Services.WebResgistraion();
            //Services for Repo and Data
            builder.Services.AddRegistrationForDataAndRepo(builder.Configuration);
            //Service Registration
            builder.Services.AddWebServicesRegistrations();

          #endregion
            var app = builder.Build();


            #region Need To Apply Data Seeding 
            await app.SeedData();
            #endregion
            //MiddleWare Apply
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
          app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            
            app.MapControllers();

            app.Run();
        }
       
    }
}
