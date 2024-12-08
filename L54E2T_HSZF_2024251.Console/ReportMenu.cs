using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Console
{
    public class ReportMenu
    {
        public static IPharaohService pharaohService;
        public static IProjectService projectService;
        public static IWorkerService workerService;
        public static void WorkersByPharaohs()
        {
            ICollection<Pharaohs> pharaohs = pharaohService.GetPharaohs();
            Dictionary<Pharaohs,int> pharaohs_workers = new Dictionary<Pharaohs, int>();
            foreach (Pharaohs pharaoh in pharaohs)
            {
                int sum = 0;
                foreach (Projects project in pharaoh.Projects)
                {
                    sum += project.Workers.Count;
                }
                pharaohs_workers.Add(pharaoh, sum);
            }
            int i = 0;
            foreach (KeyValuePair<Pharaohs, int> item in pharaohs_workers)
            {
                System.Console.WriteLine($"[{i}] | {item.Key} {item.Value}");
            }
        }
        public static void WorkersByAge()
        {
            int[] counts = new int[6];
            ICollection<Workers> workers = workerService.GetWorker();
            for (int i = 0; i < 6; i++)
            {
                counts[i] = workers.Where(x => x.Age < i * 10 + 10 && x.Age >= i * 10).Count();
            }
            for (int i = 0; i < counts.Length; i++)
            {
                System.Console.WriteLine($"{i * 10}-{i * 10 + 10 - 1} : {counts[i]}");
            }
            

        }
        public static void PharaohsByTime()
        {
            //Dictionary<int,List<Pharaohs>> pharaohs = new Dictionary<int, List<Pharaohs>>();
            //ICollection<Pharaohs>  pharaohsColl = pharaohService.GetPharaohs();
            //foreach (var item in pharaohsColl)
            //{
            //    pharaohs.Contains()
            //}
        }
        
        public static void WorkerTypesInProjects()
        {
            ICollection<Projects> projects = projectService.GetProjects();
            foreach (Projects project in projects)
            {
                System.Console.WriteLine($"{project.Name}:");
                System.Console.WriteLine($"Worker type - Worker Count");
                Dictionary<string, int> Workertypes = new Dictionary<string, int>();
                foreach (Workers worker in project.Workers)
                {
                    if (Workertypes.ContainsKey(worker.Type))
                    {
                        Workertypes[worker.Type]++;
                    }
                    else 
                    {
                        Workertypes.Add(worker.Type, 1);
                    }
                }
                foreach (KeyValuePair<string,int> types in Workertypes)
                {
                    System.Console.WriteLine($"{types} - {types.Value}");

                }
                System.Console.WriteLine();
            }
        }
        public static void PharaohsProjects()
        {
            ICollection<Pharaohs> pharaohs = pharaohService.GetPharaohs();

            foreach (Pharaohs item in pharaohs)
            {
                System.Console.WriteLine($"{item.Name} started {item.Projects.Count} project(s)");
                System.Console.WriteLine($"Project(s):");
                foreach (Projects project in item.Projects)
                {
                    System.Console.WriteLine($"{project.Name}");
                }
            }
        }
        public static void WorkerManagerRelationInProjects()
        {
            ICollection<Projects> projects = projectService.GetProjects();
            foreach (Projects project in projects)
            {
                System.Console.WriteLine($"{project.Name}:");
                foreach (Workers worker in project.Workers)
                {
                    if (worker.subWorkers.Count != 0)
                    {
                        System.Console.WriteLine($"Manager: {worker.Name}");
                        System.Console.WriteLine($"Workers:");
                        foreach (Workers subworker in worker.subWorkers)
                        {
                            System.Console.WriteLine($"{subworker.Name}");
                        }
                    }
                    
                }
            }
        }
        public static void PharaohProjects()
        {
            ICollection<Pharaohs> pharaohs = pharaohService.GetPharaohs();
            foreach (Pharaohs pharaoh in pharaohs)
            {
                string root = $@"Project\Pharaoh_{pharaoh.Id}";
            }
            
        }
    }
}
