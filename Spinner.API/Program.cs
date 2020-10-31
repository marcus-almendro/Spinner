using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Spinner.Infrastructure;

namespace Spinner.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TempDbFactory.CreateDatabase();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
