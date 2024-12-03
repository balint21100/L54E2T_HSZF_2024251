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
        public void UpdateWorkerRelationShip(int id, WorkerRelationShip WorkerRelationShip);
        public void DeleteWorkerRelationShip(int id);
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
            Pharaohs workerRelationships = DBContext.WorkerRelations.Add(oneWorkerRelationships).Entity;
            DBContext.SaveChanges();
            return workerRelationships;
        }
        public void UpdateWorkerRelationShip(int id, WorkerRelationShip  workerRelationShip)
        {
            Pharaohs newWorkerRelationShip = DBContext.WorkerRelations.First(x => x.Id == id);
            newWorkerRelationShip = workerRelationShip;
            DBContext.SaveChanges();
        }
        public void DeleteWorkerRelationShip(int id)
        {
            Pharaohs newWorkerRelationShip = DBContext.WorkerRelations.First(x => x.Id == id);
            DBContext.Remove(newWorkerRelationShip);
            DBContext.SaveChanges();
        }
        public ICollection<WorkerRelationShip> GetWorkerRelationShip()
        {
            return DBContext.WorkerRelations.ToHashSet();
        }
    }
}
