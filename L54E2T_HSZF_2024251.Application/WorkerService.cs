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
        public ICollection<Workers> GetWorker();
    }
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerDataProvider workerDataProvider;

        public WorkerService(IWorkerDataProvider workerDataProvider)
        {
            this.workerDataProvider = workerDataProvider;
        }

        public Workers AddWorker(Workers oneworker)
        {
            return workerDataProvider.AddWorker(oneworker);
        }
        public void UpdateWorker(int id, Workers workers)
        {
            workerDataProvider.UpdateWorker(id, workers);
        }
        public void DeleteWorker(Workers worker)
        {
            workerDataProvider.DeleteWorker(worker.Id);
        }
        public ICollection<Workers> GetWorker()
        {
            return workerDataProvider.GetWorker();
        }
    }
}
