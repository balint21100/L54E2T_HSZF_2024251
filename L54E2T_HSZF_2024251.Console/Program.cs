using System;
using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Console;
using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace L54E2T_HSZF_2024251.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting application...");

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
                                services.AddSingleton<IFileService, FileService>();
                                


                            })
                            .Build();


            host.Start();
            IFileService fileService = host.Services.CreateScope().ServiceProvider.GetService<IFileService>();
            IPharaohService pharaohService = host.Services.CreateScope().ServiceProvider.GetService<IPharaohService>();
            IProjectService projectService = host.Services.CreateScope().ServiceProvider.GetService<IProjectService>();
            IWorkerService workerService = host.Services.CreateScope().ServiceProvider.GetService<IWorkerService>();
            IWorkerRelationShipService relationShipService = host.Services.CreateScope().ServiceProvider.GetService<IWorkerRelationShipService>();
            ReportMenu.pharaohService = pharaohService;
            ReportMenu.workerService = workerService;
            ReportMenu.projectService = projectService;
            PharaohMenu.pharaohService = pharaohService;
            ProjectMenu.projectService = projectService;
            WorkerMenu.workerService = workerService;
            WorkerMenu.workerRelationShipService = relationShipService;
            CreateDirectory.pharaohService = pharaohService;
            fileService.Import("SeedGoodConditions.json");
            Preparations(workerService, projectService);
            CreateDirectory.CreateDirectorys();
            Menu.MainMenu();


        }

        private static void Preparations(IWorkerService workerService, IProjectService projectService)
        {
            workerService.TooOldW += x =>
            {
                System.Console.Clear();
                System.Console.WriteLine($"The {x.Name} worker is too Old ({x.Age})");
                Task.Delay(3000).Wait();
            };
            projectService.DieFast += x =>
            {
                System.Console.Clear();
                System.Console.WriteLine($"The pharaoh reign ends before the project is finished");
                Task.Delay(3000).Wait();
            };
        }

    }
    


}
