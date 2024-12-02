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
        public WorkerRelationShip AddWorkerRelationShip(WorkerRelationShip onePharaoh);
        public void UpdateWorkerRelationShip(int id, WorkerRelationShip pharaohs);
        public void DeleteWorkerRelationShip(WorkerRelationShip pharaohs);
        public ICollection<WorkerRelationShip> GetWorkerRelationShipByFilter(Func<WorkerRelationShip, bool> filter);
        public ICollection<WorkerRelationShip> GetWorkerRelationShip();
    }
    public class WorkerRelationShipService
    {
        private readonly IWorkerRelationshipsDataProvider  workerRelationshipsDataProvider;
        public WorkerRelationShipService(IWorkerRelationshipsDataProvider workerRelationshipsDataProvider)
        {
            this.workerRelationshipsDataProvider = workerRelationshipsDataProvider;
        }

        public WorkerRelationShip AddWorkerRelationShip(WorkerRelationShip onePharaoh)
        {
            return workerRelationshipsDataProvider.AddWorkerRelationships(onePharaoh);
        }
        public void UpdateWorkerRelationShip(int id, WorkerRelationShip pharaohs)
        {
            workerRelationshipsDataProvider.UpdateWorkerRelationShip(id, pharaohs);
        }
        public void DeleteWorkerRelationShip(WorkerRelationShip pharaohs)
        {
            workerRelationshipsDataProvider.DeleteWorkerRelationShip(pharaohs.Id);
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
