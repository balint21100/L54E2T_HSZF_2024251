using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace L54E2T_HSZF_2024251.Console
{
    public class ReportMenu
    {
        public static IPharaohService pharaohService;
        public static IProjectService projectService;
        public static IWorkerService workerService;
        public static void WorkersByPharaohs()
        {
            System.Console.Clear();
            System.Console.WriteLine("Workers count by pharaohs");
            System.Console.WriteLine();
            

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
            System.Console.WriteLine();
            System.Console.WriteLine("Nr. | Pharaoh name | Workers count");
            System.Console.WriteLine("");
            int i = 0;
            foreach (KeyValuePair<Pharaohs, int> item in pharaohs_workers)
            {
                System.Console.WriteLine($"[{i}] | {item.Key.Name} | {item.Value}");
                i++;
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key");
            System.Console.ReadKey();
        }
        public static void WorkersByAge()
        {
            System.Console.Clear();
            System.Console.WriteLine("Workers by age");
            System.Console.WriteLine();
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
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key");
            System.Console.ReadKey();

        }
        public static void PharaohsByTime()
        {
            System.Console.Clear();
            System.Console.WriteLine($"Pharaohs Between times");
            DateTime StartDate;
            DateTime EndDate;
            string input;
            string iput;
            do
            {
                System.Console.WriteLine("Please enter the start date (Correct format YYYY.MM.DD)");
                System.Console.WriteLine() ;
                
                System.Console.Write("Start date: ");
               input = System.Console.ReadLine();
            } while (!InputCheckForMenus.DateTimeCheck(input) && input != "exit");

            StartDate = Convert.ToDateTime(input);
            do
            {
                if (input!= "exit")
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Please enter the end date (Correct format YYYY.MM.DD)");
                    System.Console.WriteLine();

                    System.Console.Write("Start end: ");
                    iput = System.Console.ReadLine();
                }
                else
                {
                    iput = input;
                }
                
            } while (!InputCheckForMenus.DateTimeCheck(iput) && iput != "exit");
            if (input != "exit" && iput != "exit")
            {
                EndDate = Convert.ToDateTime(iput);

                ICollection<Pharaohs> pharaohs = pharaohService.GetPharaohs();
                List<string> pharaoh = pharaohs.Where(x => x.Reign_Start > StartDate && x.Reign_End < EndDate).Select(x => x.Name).ToList();
                System.Console.Clear();
                System.Console.WriteLine($"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}");
                System.Console.WriteLine();
                foreach (string item in pharaoh)
                {
                    System.Console.WriteLine($"{item}");
                }
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Press any key");
            System.Console.ReadKey();
        }
        
        public static void WorkerTypesInProjects()
        {
            System.Console.Clear();
            System.Console.WriteLine("Workers count by types in projects");
            System.Console.WriteLine();
            System.Console.WriteLine($"Worker type - Worker Count");
            System.Console.WriteLine();
            ICollection<Projects> projects = projectService.GetProjects();
            foreach (Projects project in projects)
            {
                System.Console.WriteLine($"{project.Name}:");
                System.Console.WriteLine($"");
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
                    System.Console.WriteLine($" \t{types.Key} - {types.Value}");

                }
                System.Console.WriteLine();
            }
            
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key");
            System.Console.ReadKey();
        }
        public static void SearchByType()
        {
            System.Console.Clear();
            System.Console.WriteLine("Please enter a worker type");
            string input = string.Empty;
            while (input == string.Empty && input != "exit")
            {
                System.Console.Write("Worker type:");
                input = System.Console.ReadLine();
            }
            IEnumerable<Projects> projects = projectService.GetProjects().Where(x =>
            {
                foreach (Workers worker in x.Workers)
                {
                    if (worker.Type == input)
                    {
                        return true;
                    }
                }
                return false;
            });
            System.Console.Clear();
            System.Console.WriteLine($"Project with worker with this type: {input}");
            System.Console.WriteLine();
            System.Console.WriteLine($"Project name | start date | workers with this type");
            System.Console.WriteLine();
            foreach (Projects project in projects)
            {
                System.Console.WriteLine($"{project.Name} | {project.Start_date.ToShortDateString()} | {project.Workers.Count(x => x.Type == input)}");
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key");
            System.Console.ReadKey();
        }

        public static void PharaohsProjects()
        {
            System.Console.Clear();
            System.Console.WriteLine("Pharaohs all projects count");
            System.Console.WriteLine();
            ICollection<Pharaohs> pharaohs = pharaohService.GetPharaohs();

            foreach (Pharaohs item in pharaohs)
            {
                System.Console.WriteLine($"{item.Name} started {item.Projects.Count} project(s)");
                System.Console.WriteLine($"\tProject(s):");
                foreach (Projects project in item.Projects)
                {
                    System.Console.WriteLine($"\t\t{project.Name}");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key");
            System.Console.ReadKey();
        }
        public static void WorkerManagerRelationInProjects()
        {
            System.Console.Clear();
            System.Console.WriteLine("Manager worker relationships");
            System.Console.WriteLine();
            ICollection<Projects> projects = projectService.GetProjects();
            foreach (Projects project in projects)
            {
                System.Console.WriteLine($"{project.Name}:");
                foreach (Workers worker in project.Workers)
                {
                    if (worker.subWorkers.Count != 0)
                    {
                        System.Console.WriteLine($"\tManager: {worker.Name}");
                        System.Console.WriteLine($"\t\tWorkers:");
                        foreach (Workers subworker in worker.subWorkers)
                        {
                            System.Console.WriteLine($"\t\t\t{subworker.Name}");
                        }
                        System.Console.WriteLine($"");
                    }
                    
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key");
            System.Console.ReadKey();
        }
        public static void PharaohProjects()
        {
            System.Console.Clear();
            System.Console.WriteLine("Projects data in xml");
            System.Console.WriteLine();
            CreateDirectory.CreateDirectorys();
            ICollection<Pharaohs> pharaohs = pharaohService.GetPharaohs();
            foreach (Pharaohs pharaoh in pharaohs)
            {

                string root = $@"Projects\Pharaoh_{pharaoh.Id}";
                
                foreach (Projects projectz in pharaoh.Projects)
                {
                    XmlWriter writer = XmlWriter.Create($@"{root}\{projectz.Name}.xml");
                    writer.WriteStartDocument();


                    
                    writer.WriteStartElement($"Project");
                    writer.WriteElementString($"Name", $"{projectz.Name}");
                    writer.WriteElementString($"StartDate", $"{projectz.Start_date.ToShortDateString()}");
                    writer.WriteElementString($"EndDate", $"{projectz.End_date.ToShortDateString()}");
                    writer.WriteElementString($"WorkersCount", $"{projectz.WorkerCount}");
                    writer.WriteElementString($"ProjectValue", $"{projectz.ProjectValue}");
                    writer.WriteEndElement();
                    writer.Flush();
                    writer.Close();
                }
                

            }
            System.Console.WriteLine();
            System.Console.WriteLine($"The reports successfully generated in the Projects folder");
            System.Console.WriteLine();

            System.Console.WriteLine("Press any key");
            System.Console.ReadKey();

        }
    }
}
