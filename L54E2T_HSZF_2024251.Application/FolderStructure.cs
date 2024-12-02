using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Application
{
    public interface IFolderStructure
    {
        public void CreatePharaohProjectDirectory(int pharaohId);
    }
    public class FolderStructure : IFolderStructure
    {
        public void CreatePharaohProjectDirectory(int pharaohId)
        {
            
            string rootDirectory = "Projects";

            
            string pharaohDirectory = Path.Combine(rootDirectory, $"Pharaoh_{pharaohId}");

            
            if (!Directory.Exists(pharaohDirectory))
            {
                Directory.CreateDirectory(pharaohDirectory);
            }
        }
    }
}
