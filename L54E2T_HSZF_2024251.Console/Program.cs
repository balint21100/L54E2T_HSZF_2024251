using System;
using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace L54E2T_HSZF_2024251.Console2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting application...");

            var host = Host.CreateDefaultBuilder()
                            .ConfigureServices((hostContext, services) =>
                            {
                                services.AddScoped<EgyptDb>();

                                services.AddSingleton<IDataService, DataService>();
                                services.AddSingleton<IPahraohDataProvider, PahraohDataProvider>();
                                services.AddSingleton<IProjectDataProvider, ProjectDataProvider>();
                                services.AddSingleton<IWorkerDataProvider, WorkerDataProvider>();
                                services.AddSingleton<IReport, Report>();


                            })
                            .Build();
            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;

            IDataService dataService = serviceProvider.GetRequiredService<IDataService>();

            host.Start();
            Menu menu = new Menu();
            menu.MainMenu(dataService);


        }

        

    }


}
