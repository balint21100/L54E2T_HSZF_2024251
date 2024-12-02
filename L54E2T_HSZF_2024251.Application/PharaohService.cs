using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Application
{
    public interface IPharaohService
    {
        public WorkerRelationShip AddPharaoh(WorkerRelationShip onePharaoh);
        public void UpdatePharaoh(int id, WorkerRelationShip pharaohs);
        public void DeletePharaoh(WorkerRelationShip pharaohs);
        public ICollection<WorkerRelationShip> GetPharaohsByFilter(Func<WorkerRelationShip, bool> filter);
        public ICollection<WorkerRelationShip> GetPharaohs();
    }
    public class PharaohService : IPharaohService
    {
        private readonly IPharaohDataProvider pharaohDataProvider;
        public PharaohService(IPharaohDataProvider pharaohDataProvider)
        {
            this.pharaohDataProvider = pharaohDataProvider;
        }
        public WorkerRelationShip AddPharaoh(WorkerRelationShip onePharaoh)
        {
            return pharaohDataProvider.AddPharaoh(onePharaoh);
        }
        public void UpdatePharaoh(int id, WorkerRelationShip pharaohs)
        {
            pharaohDataProvider.UpdatePharaoh(id, pharaohs);
        }
        public void DeletePharaoh(WorkerRelationShip pharaohs)
        {
            pharaohDataProvider.DeletePharaoh(pharaohs.Id);
        }
        public ICollection<WorkerRelationShip> GetPharaohs()
        {
            return pharaohDataProvider.GetPharaohs();
        }
        public ICollection<WorkerRelationShip> GetPharaohsByFilter(Func<WorkerRelationShip,bool> filter)
        {
            return pharaohDataProvider.GetPharaohs().Where(filter).ToHashSet();
        }
    }
}
