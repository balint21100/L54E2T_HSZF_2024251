using L54E2T_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Persistence.MsSql
{
    public interface IWorkerDataProvider
    {
        public bool AddWorker(Workers worker);
        public bool DeleteWorkerFrominDB(Workers worker);
        public Workers[] SearchWorkerByIdInDB(int workerId);

        public Workers[] SearchWorkerByNameInDB(string workerName);

        public Workers[] SearchWorkerByAgeInDB(int workerAge);

        public Workers[] SearchWorkerByTypeInDB(string workerType);
    }
    public class WorkerDataProvider : IWorkerDataProvider
    {
        private readonly EgyptDb DBContext;
        public WorkerDataProvider(EgyptDb egyptDb)
        {
            DBContext = egyptDb;
        }
        public bool AddWorker(Workers worker)
        {
            DBContext.Workers.Add(worker);
            DBContext.SaveChanges();
            return true;
        }
        public bool DeleteWorkerFrominDB(Workers worker)
        {
            DBContext.Workers.Remove(worker);
            DBContext.SaveChanges();
            return true;
        }
        public Workers[] SearchWorkerByIdInDB(int workerId)
        {
            Workers[] workersWithThisName = DBContext.Workers.Where(x => x.Id == workerId).ToArray();
            return workersWithThisName;
        }
        public Workers[] SearchWorkerByNameInDB(string workerName)
        {
            Workers[] workersWithThisName = DBContext.Workers.Where(x => x.Name == workerName).ToArray();
            return workersWithThisName;
        }
        public Workers[] SearchWorkerByAgeInDB(int workerAge)
        {
            Workers[] workersWithThisAge = DBContext.Workers.Where(x => x.Age == workerAge).ToArray();
            return workersWithThisAge;
        }
        public Workers[] SearchWorkerByTypeInDB(string workerType)
        {
            Workers[] workersWithThisType = DBContext.Workers.Where(x => x.Type == workerType).ToArray();
            return workersWithThisType;
        }
    }
}
