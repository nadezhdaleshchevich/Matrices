using System;
using Microsoft.Extensions.DependencyInjection;

namespace Matrices.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var app = serviceProvider.GetService<MyApplication>();
                app.Run();
            }

            Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILogger, Logger>();
            services.AddTransient<MyApplication>();
        }
    }
}
