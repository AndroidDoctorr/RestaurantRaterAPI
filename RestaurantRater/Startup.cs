using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestaurantRater.Data;
using RestaurantRater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater
{
    public class Startup
    {
        // 2: Explain the startup class - here we establish the app configuration - routing, authorization, services, etc. We need to add services
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // 3: Set up connection string to database

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            // 4: Now we need to establish our folder structure:

            // - Add Models/ Services/ and Data/ folders.
            // - Data/ will have an Entities/ folder for the data models
            // - Services/ will contain a Restaurant/ folder for IRestaurantService.cs and RestaurantService.cs

            // 5: Add our application DB context (We will create it in an upcoming step, or you can skip ahead to creating the Restaurant Entity, then the ApplicationDbContext)

            // Install-Package Microsoft.Extensions.DependencyInjection
            // Install-Package Microsoft.EntityFrameworkCore.SqlServer

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // 6: Add Services (this allows us to use dependency injection with our services so we don't have to instantiate our dbContexts in them. They are interchangeable this way)

            // These classes don't exist yet - you can create them first instead if you like. Otherwise move on to the data model if that doesn't exist yet

            services.AddScoped<IRestaurantService, RestaurantService>();

            // Next, do this same process for the Rating model...

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
