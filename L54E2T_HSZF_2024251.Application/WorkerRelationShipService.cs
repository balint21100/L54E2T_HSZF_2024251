using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Application
{
    public interface IWorkerRelationShipService
    {
        public WorkerRelationShip AddWorkerRelationShip(WorkerRelationShip oneWorkerRelationShip);
        public void UpdateWorkerRelationShip(Workers workers, Workers manager, Workers newManager);
        public void DeleteWorkerRelationShip(Workers workers, Workers manager);
        public ICollection<WorkerRelationShip> GetWorkerRelationShipByFilter(Func<WorkerRelationShip, bool> filter);
        public ICollection<WorkerRelationShip> GetWorkerRelationShip();
    }
    public class WorkerRelationShipService : IWorkerRelationShipService
    {
        private readonly IWorkerRelationshipsDataProvider  workerRelationshipsDataProvider;
        public WorkerRelationShipService(IWorkerRelationshipsDataProvider workerRelationshipsDataProvider)
        {
            this.workerRelationshipsDataProvider = workerRelationshipsDataProvider;
        }

        public WorkerRelationShip AddWorkerRelationShip(WorkerRelationShip workerRelationShip)
        {
            return workerRelationshipsDataProvider.AddWorkerRelationships(workerRelationShip);
        }
        public void UpdateWorkerRelationShip(Workers workers, Workers manager, Workers newManager)
        {
            WorkerRelationShip wr = workerRelationshipsDataProvider.GetWorkerRelationShip().First(x => x.WorkerId == workers.Id && x.ManagerId == manager.Id);
            int oldmanagerid = wr.ManagerId;
            wr.ManagerId = newManager.Id;
            workerRelationshipsDataProvider.UpdateWorkerRelationShip(oldmanagerid,wr.WorkerId, wr);
        }
        public void DeleteWorkerRelationShip(Workers workers, Workers manager)
        {
            
            workerRelationshipsDataProvider.DeleteWorkerRelationShip(manager.Id, workers.Id);
        }
        public ICollection<WorkerRelationShip> GetWorkerRelationShip()
        {
            return workerRelationshipsDataProvider.GetWorkerRelationShip();
        }
        public ICollection<WorkerRelationShip> GetWorkerRelationShipByFilter(Func<WorkerRelationShip, bool> filter)
        {
            return workerRelationshipsDataProvider.GetWorkerRelationShip().Where(filter).ToHashSet();
        }
    }
}
