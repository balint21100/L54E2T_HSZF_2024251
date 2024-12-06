using L54E2T_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Persistence.MsSql
{
    public interface IWorkerRelationshipsDataProvider
    {
        public WorkerRelationShip AddWorkerRelationships(WorkerRelationShip oneWorkerRelationShip);
        public void UpdateWorkerRelationShip(int managerid, int workerid, WorkerRelationShip workerRelationShip);
        public void DeleteWorkerRelationShip(int managerid, int workerid);
        public ICollection<WorkerRelationShip> GetWorkerRelationShip();
    }
    public class WorkerRelationshipsDataProvider : IWorkerRelationshipsDataProvider
    {
        private readonly EgyptDb DBContext;
        public WorkerRelationshipsDataProvider(EgyptDb egyptDb)
        {
            DBContext = egyptDb;
        }
        public WorkerRelationShip AddWorkerRelationships(WorkerRelationShip oneWorkerRelationships)
        {
            WorkerRelationShip workerRelationships = DBContext.WorkerRelations.Add(oneWorkerRelationships).Entity;
            DBContext.SaveChanges();
            return workerRelationships;
        }
        public void UpdateWorkerRelationShip(int managerid,int workerid, WorkerRelationShip  workerRelationShip)
        {
            WorkerRelationShip newWorkerRelationShip = DBContext.WorkerRelations.First(x => x.WorkerId == workerid && x.ManagerId == managerid);
            newWorkerRelationShip = workerRelationShip;
            DBContext.SaveChanges();
        }
        public void DeleteWorkerRelationShip(int managerid, int workerid)
        {
            WorkerRelationShip newWorkerRelationShip = DBContext.WorkerRelations.First(x => x.WorkerId == workerid && x.ManagerId == managerid);
            DBContext.Remove(newWorkerRelationShip);
            DBContext.SaveChanges();
        }
        public ICollection<WorkerRelationShip> GetWorkerRelationShip()
        {
            return DBContext.WorkerRelations.ToHashSet();
        }
    }
}
