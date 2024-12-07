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
                                


                            })
                            .Build();


            host.Start();

            IPharaohService pharaohService = host.Services.CreateScope().ServiceProvider.GetService<IPharaohService>();
            IProjectService projectService = host.Services.CreateScope().ServiceProvider.GetService<IProjectService>();
            IWorkerService workerService = host.Services.CreateScope().ServiceProvider.GetService<IWorkerService>();
            IWorkerRelationShipService relationShipService = host.Services.CreateScope().ServiceProvider.GetService<IWorkerRelationShipService>();
            ReportMenu.pharaohService = pharaohService;
            ReportMenu.workerService = workerService;
            PharaohMenu.pharaohService = pharaohService;
            ProjectMenu.projectService = projectService;
            WorkerMenu.workerService = workerService;
            WorkerMenu.workerRelationShipService = relationShipService;
            Pharaohs p =  pharaohService.AddPharaoh(new Model.Pharaohs
            {
                Name = "Ramses",
                Reign_Start = Convert.ToDateTime("2002-02-12"),
                Reign_End = Convert.ToDateTime("2002-08-12")
            });
            Projects p2 = projectService.AddProjects(new Model.Projects
            {
                Name = "asd",
                Start_date = Convert.ToDateTime("2002-02-12"),
                End_date = Convert.ToDateTime("2002-08-12"),
                PharaoId = p.Id
            });
            Workers Lajos = workerService.AddWorker(new Model.Workers
            {
                Name = "Lajos",
                Age = 18,
                Type = "raktaros",
                ProjectId = p2.Id
            });
            Workers Janos = workerService.AddWorker(new Model.Workers
            {
                Name = "János",
                Age = 18,
                Type = "raktaros",
                ProjectId = p2.Id
            });
            Workers Viktor = workerService.AddWorker(new Model.Workers
            {
                Name = "Viktor",
                Age = 18,
                Type = "raktaros",
                ProjectId = p2.Id
            });
            Workers Istvan = workerService.AddWorker(new Model.Workers
            {
                Name = "Viktor",
                Age = 18,
                Type = "raktaros",
                ProjectId = p2.Id
            });
            Workers Jozsi = workerService.AddWorker(new Model.Workers
            {
                Name = "Viktor",
                Age = 18,
                Type = "raktaros",
                ProjectId = p2.Id
            });
            WorkerRelationShip wrs = new WorkerRelationShip(){
                ManagerId = Lajos.Id,
                WorkerId = Janos.Id
                
            };
            WorkerRelationShip wrs2 = new WorkerRelationShip()
            {
                ManagerId = Janos.Id,
                WorkerId = Viktor.Id

            };
            WorkerRelationShip wrs3 = new WorkerRelationShip()
            {
                ManagerId = Viktor.Id,
                WorkerId = Istvan.Id

            };
            WorkerRelationShip wrs4 = new WorkerRelationShip()
            {
                ManagerId = Istvan.Id,
                WorkerId = Jozsi.Id

            };
            WorkerRelationShip wrs5 = new WorkerRelationShip()
            {
                ManagerId = Jozsi.Id,
                WorkerId = Lajos.Id

            };
            relationShipService.AddWorkerRelationShip(wrs);
            relationShipService.AddWorkerRelationShip(wrs2);
            try
            {
                relationShipService.AddWorkerRelationShip(wrs3);
                relationShipService.AddWorkerRelationShip(wrs4);
                relationShipService.AddWorkerRelationShip(wrs5);
            }
            catch (ArgumentException e)
            {

                System.Console.WriteLine(e.Message);
            }
            System.Console.ReadKey();
            
            Menu.MainMenu();


        }

        

    }


}
