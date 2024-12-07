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
        private readonly IWorkerRelationshipsDataProvider workerRelationshipsDataProvider;
        private readonly IWorkerDataProvider workerDataProvider;
        
        public WorkerRelationShipService(IWorkerRelationshipsDataProvider workerRelationshipsDataProvider, IWorkerDataProvider workerDataProvider)
        {
            this.workerRelationshipsDataProvider = workerRelationshipsDataProvider;
            this.workerDataProvider = workerDataProvider;
        }

        public WorkerRelationShip AddWorkerRelationShip(WorkerRelationShip workerRelationShip)
        {
            bool found = false;
            if (workerRelationShip.WorkerId == workerRelationShip.ManagerId)
            {
                throw new ArgumentException("Error! The worker and the manager is the same");
            }
            
            Workers workers = workerDataProvider.GetWorker().First(x => x.Id == workerRelationShip.WorkerId);
            if (ManagerFoundInSubWorkers(workers, workerRelationShip.ManagerId))
            {
                throw new ArgumentException("Error! The manager is found in subworkers");
            }
            /*if (ManagerFoundInSubWorkers(workers.subWorkers, workerRelationShip.ManagerId, ref found))
            {
                throw new ArgumentException("Error! The manager is found in subworkers");
            }*/
            return workerRelationshipsDataProvider.AddWorkerRelationships(workerRelationShip);
        }
        private bool ManagerFoundInSubWorkers(Workers worker, int managerid)
        {
            if (worker.subWorkers.Any(x => x.Id == managerid))
            {
                return true;
            }
            foreach (var item in worker.subWorkers)
            {
                if (ManagerFoundInSubWorkers(item, managerid))
                {
                    return true;
                }
            }
            return false;
        }
        /*private bool ManagerFoundInSubWorkers(ICollection<Workers> subworkers, int managerid, ref bool found)
        {

            if (subworkers != null && !found )
            {
                foreach (var item in subworkers)
                {
                    if (item.Id == managerid)
                    {
                        return true;
                    }
                    found = ManagerFoundInSubWorkers(item.subWorkers, managerid, ref found);

                }
                return found;
            
            }
            return found;
        }*/

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
