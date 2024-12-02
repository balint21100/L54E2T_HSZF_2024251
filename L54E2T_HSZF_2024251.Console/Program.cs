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

                                services.AddSingleton<IPharaohDataProvider, PharaohDataProvider>();
                                services.AddSingleton<IProjectDataProvider, ProjectDataProvider>();
                                services.AddSingleton<IWorkerDataProvider, WorkerDataProvider>();
                                services.AddSingleton<IWorkerRelationshipsDataProvider, WorkerRelationshipsDataProvider>();
                                services.AddSingleton<IPharaohService, PharaohService>();
                                services.AddSingleton<IProjectService, ProjectService>();
                                services.AddSingleton<IWorkerService, WorkerService>();
                                services.AddSingleton<IWorkerRelationShipService, WorkerRelationShipService>();
                                


                            })
                            .Build();


            host.Start();

            IPharaohService pharaohService = host.Services.CreateScope().ServiceProvider.GetService<IPharaohService>();
            IProjectService projectService = host.Services.CreateScope().ServiceProvider.GetService<IProjectService>();
            IWorkerService workerService = host.Services.CreateScope().ServiceProvider.GetService<IWorkerService>();
            IWorkerRelationShipService relationShipService = host.Services.CreateScope().ServiceProvider.GetService<IWorkerRelationShipService>();
            
            Menu menu = new Menu();
            menu.MainMenu();


        }

        

    }


}
