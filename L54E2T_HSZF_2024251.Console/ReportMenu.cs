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
    }
}
