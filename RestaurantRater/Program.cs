using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRater
{
    public class Program
    {
        // 0: Explain what's happening here - Main calls CreateHostBuilder which creates a builder, which then builds the application, and then Run() is called on the application that Build() returns.

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        // 1: CreateHostBuilder returns the builder which builds the web application using our Startup class...
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
