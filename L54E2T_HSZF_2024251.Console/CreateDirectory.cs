using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Console
{
    public class CreateDirectory
    {
        public static IPharaohService pharaohService;
        public static void CreateDirectorys()
        {
            string root = @"Projects";
            // If directory does not exist, create it.
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            ICollection<Pharaohs> pharaohs = pharaohService.GetPharaohs();
            foreach (Pharaohs pharaoh in pharaohs)
            {
                string subdir = $@"Project\Pharaoh_{pharaoh.Id}";
                if (!Directory.Exists(subdir))
                {
                    Directory.CreateDirectory(subdir);
                }
            }
        }
    }
}
