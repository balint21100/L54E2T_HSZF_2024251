using L54E2T_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Persistence.MsSql
{
    public interface IPharaohDataProvider
    {
        public WorkerRelationShip AddPharaoh(WorkerRelationShip onePharaoh);
        public void UpdatePharaoh(int id, WorkerRelationShip pharaohs);
        public void DeletePharaoh(int id);
        public ICollection<WorkerRelationShip> GetPharaohs();
    }
    public class PharaohDataProvider : IPharaohDataProvider
    {
        private readonly EgyptDb DBContext;
        public PharaohDataProvider(EgyptDb egyptDb)
        {
            DBContext = egyptDb;
        }
        
        public WorkerRelationShip AddPharaoh(WorkerRelationShip onePharaoh)
        {
            WorkerRelationShip pharaohs = DBContext.Pharaohs.Add(onePharaoh).Entity;
            DBContext.SaveChanges();
            return pharaohs;
        }
        public void UpdatePharaoh(int id, WorkerRelationShip pharaohs)
        {
            WorkerRelationShip newPharaoh = DBContext.Pharaohs.First(x => x.Id == id);
            newPharaoh = pharaohs;
            DBContext.SaveChanges();
        }
        public void DeletePharaoh(int id)
        {
            WorkerRelationShip newPharaoh = DBContext.Pharaohs.First(x => x.Id == id);
            DBContext.Remove(newPharaoh);
            DBContext.SaveChanges();
        }
        public ICollection<WorkerRelationShip> GetPharaohs()
        {
            return DBContext.Pharaohs.ToHashSet();
        }
    }
}
