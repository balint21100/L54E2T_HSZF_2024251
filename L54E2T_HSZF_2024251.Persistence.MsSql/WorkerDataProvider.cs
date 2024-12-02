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
        
        public bool DeleteWorkerFrominDB(Workers worker);




        public Workers AddWorker(Workers oneworker);
        public void UpdateWorker(int id, Workers workers);
        public void DeleteWorker(int id);
        public ICollection<Workers> GetWorker();
    }
    public class WorkerDataProvider : IWorkerDataProvider
    {
        private readonly EgyptDb DBContext;
        public WorkerDataProvider(EgyptDb egyptDb)
        {
            DBContext = egyptDb;
        }
        //public bool AddWorker(Workers worker)
        //{
        //    DBContext.Workers.Add(worker);
        //    DBContext.SaveChanges();
        //    return true;
        //}
        public bool DeleteWorkerFrominDB(Workers worker)
        {
            DBContext.Workers.Remove(worker);
            DBContext.SaveChanges();
            return true;
        }
        





        public Workers AddWorker(Workers oneworker)
        {
            Workers worker = DBContext.Workers.Add(oneworker).Entity;
            DBContext.SaveChanges();
            return worker;
        }
        public void UpdateWorker(int id, Workers workers)
        {
            Workers newworker = DBContext.Workers.First(x => x.Id == id);
            workers = newworker;
            DBContext.SaveChanges();
        }
        public void DeleteWorker(int id)
        {
            Workers newworker = DBContext.Workers.First(x => x.Id == id);
            DBContext.Remove(newworker);
            DBContext.SaveChanges();
        }
        public ICollection<Workers> GetWorker()
        {
            return DBContext.Workers.ToHashSet();
        }

    }
}
