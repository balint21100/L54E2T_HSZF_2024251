using L54E2T_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Persistence.MsSql
{
    public interface IPahraohDataProvider
    {
        public int[] GetPharaohId();
        public string[] GetPharaohs();
    }
    public class PahraohDataProvider : IPahraohDataProvider
    {
        private readonly EgyptDb DBContext;
        public PahraohDataProvider(EgyptDb egyptDb)
        {
            DBContext = egyptDb;
        }
        public int[] GetPharaohId()
        {
            int[] pharaohIds = DBContext.Pharaohs.Select(x => x.Id).ToArray();
            return pharaohIds;
        }
        public string[] GetPharaohs()
        {
            Pharaohs[] pharaohs = DBContext.Pharaohs.Select(x => x).ToArray();
            List<string> pharaohslist = new List<string>();
            foreach (var item in pharaohs)
            {
                string s = $"{item.Id} {item.Name} {item.Reign_Start} {item.Reign_End}";
                pharaohslist.Add(s);
            }
            return pharaohslist.ToArray();
        }
    }
}
