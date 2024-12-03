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
        public ICollection<Pharaohs> GetWorkerRelationShipByFilter(Func<Pharaohs, bool> filter);
        public ICollection<Pharaohs> GetWorkerRelationShip();
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
            Pharaohs wr = workerRelationshipsDataProvider.GetWorkerRelationShip().First(x => x.WorkerId == workers.Id && x.ManagerId == manager.Id);
            wr.ManagerId = newManager.Id;
            workerRelationshipsDataProvider.UpdateWorkerRelationShip(wr.Id, wr);
        }
        public void DeleteWorkerRelationShip(Workers workers, Workers manager)
        {
            int id = workerRelationshipsDataProvider.GetWorkerRelationShip().First(x => x.WorkerId == workers.Id && x.ManagerId == manager.Id).Id;
            workerRelationshipsDataProvider.DeleteWorkerRelationShip(id);
        }
        public ICollection<Pharaohs> GetWorkerRelationShip()
        {
            return workerRelationshipsDataProvider.GetWorkerRelationShip();
        }
        public ICollection<Pharaohs> GetWorkerRelationShipByFilter(Func<Pharaohs, bool> filter)
        {
            return workerRelationshipsDataProvider.GetWorkerRelationShip().Where(filter).ToHashSet();
        }
    }
}
