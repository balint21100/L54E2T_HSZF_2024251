using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Application
{
    public interface IWorkerService
    {
        public Workers AddWorker(Workers oneworker);
        public void UpdateWorker(int id, Workers workers);
        public void DeleteWorker(Workers worker);
        public event Action<Workers> TooOldW;
        public ICollection<Workers> GetWorkersByFilter(Func<Workers, bool> filter);
        public ICollection<Workers> GetWorker();
    }
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerDataProvider workerDataProvider;
        private readonly IProjectDataProvider projectDataProvider;
        public event Action<Workers> TooOldW;

        public WorkerService(IWorkerDataProvider workerDataProvider, IProjectDataProvider projectDataProvider)
        {
            this.workerDataProvider = workerDataProvider;
            this.projectDataProvider = projectDataProvider;
        }

        public Workers AddWorker(Workers oneworker)
        {
            if (!projectDataProvider.GetProjects().Any(x => x.Id == oneworker.ProjectId))
            {
                throw new ArgumentException("Error! Project not found.");
            }
            if (oneworker.Age > 59)
            {
                TooOldW?.Invoke(oneworker);
            }
            return workerDataProvider.AddWorker(oneworker);
        }
        public void UpdateWorker(int id, Workers workers)
        {
            if (!projectDataProvider.GetProjects().Any(x => x.Id == workers.ProjectId))
            {
                throw new ArgumentException("Error! Project not found.");
            }
            if (workers.Age > 59)
            {
                TooOldW?.Invoke(workers);
            }
            workerDataProvider.UpdateWorker(id, workers);
        }
        public void DeleteWorker(Workers worker)
        {
            if (worker == null)
            {
                throw new ArgumentException("Worker not found");
            }
            workerDataProvider.DeleteWorker(worker.Id);
        }
        public ICollection<Workers> GetWorker()
        {
            return workerDataProvider.GetWorker();
        }
        public ICollection<Workers> GetWorkersByFilter(Func<Workers, bool> filter)
        {
            return workerDataProvider.GetWorker().Where(filter).ToHashSet();
        }
    }
}
