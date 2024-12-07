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
        public Pharaohs AddPharaoh(Pharaohs onePharaoh);
        public void UpdatePharaoh(int id, Pharaohs pharaohs);
        public void DeletePharaoh(Pharaohs pharaohs);
        public ICollection<Pharaohs> GetPharaohsByFilter(Func<Pharaohs, bool> filter);
        public ICollection<Pharaohs> GetPharaohs();
    }
    public class PharaohService : IPharaohService
    {
        private readonly IPharaohDataProvider pharaohDataProvider;
        public PharaohService(IPharaohDataProvider pharaohDataProvider)
        {
            this.pharaohDataProvider = pharaohDataProvider;
        }
        public Pharaohs AddPharaoh(Pharaohs onePharaoh)
        {
            return pharaohDataProvider.AddPharaoh(onePharaoh);
        }
        public void UpdatePharaoh(int id, Pharaohs pharaohs)
        {
            if (pharaohs.Reign_Start > pharaohs.Reign_End)
            {
                throw new ArgumentException();
            }
            else
            {
                pharaohDataProvider.UpdatePharaoh(id, pharaohs);
            }
            
        }
        public void DeletePharaoh(Pharaohs pharaohs)
        {
            pharaohDataProvider.DeletePharaoh(pharaohs.Id);
        }
        public ICollection<Pharaohs> GetPharaohs()
        {
            return pharaohDataProvider.GetPharaohs();
        }
        public ICollection<Pharaohs> GetPharaohsByFilter(Func<Pharaohs,bool> filter)
        {
            return pharaohDataProvider.GetPharaohs().Where(filter).ToHashSet();
        }
    }
}
