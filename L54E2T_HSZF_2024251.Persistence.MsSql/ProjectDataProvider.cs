using L54E2T_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Persistence.MsSql
{
    public interface IProjectDataProvider
    {
        public bool AddProject(Projects project);
        public string[] GetProjects();
        public List<Projects> ProjectsName(string workers);
    }
    public class ProjectDataProvider : IProjectDataProvider
    {
        private readonly EgyptDb DBContext;
        public ProjectDataProvider(EgyptDb egyptDb)
        {
            DBContext = egyptDb;
        }
        public bool AddProject(Projects project)
        {
            DBContext.Projects.Add(project);
            DBContext.SaveChanges();
            return true;
        }
        public string[] GetProjects()
        {
            Projects[] project = DBContext.Projects.Select(x => x).ToArray();
            List<string> projectslist = new List<string>();
            foreach (var item in project)
            {
                string s = $"{item.Id} {item.Name} {item.Start_date} {item.End_date} {item.PharaoId}";
                projectslist.Add(s);
            }
            return projectslist.ToArray();
        }
        public List<Projects> ProjectsName(string workers)
        {
            var projectsWithWorkerType = DBContext.Projects
                                                .Where(p => p.Workers.Any(w => w.Type == workers))
                                                .Include(p => p.Workers)
                                                .ToList();
            return projectsWithWorkerType;
        }
    }
    
}
