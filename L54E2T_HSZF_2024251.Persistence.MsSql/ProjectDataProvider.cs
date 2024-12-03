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
        public Projects AddProjects(Projects oneProject);
        public void UpdateProjects(int id, Projects projects);
        public void DeleteProjects(int id);
        public ICollection<Projects> GetProjects();
    }
    public class ProjectDataProvider : IProjectDataProvider
    {
        private readonly EgyptDb DBContext;
        public ProjectDataProvider(EgyptDb egyptDb)
        {
            DBContext = egyptDb;
        }
        
        public Projects AddProjects(Projects oneProject)
        {
            Projects projects = DBContext.Projects.Add(oneProject).Entity;
            DBContext.SaveChanges();
            return projects;
        }
        public void UpdateProjects(int id, Projects projects)
        {
            Projects newProject = DBContext.Projects.First(x => x.Id == id);
            newProject = projects;
            DBContext.SaveChanges();
        }
        public void DeleteProjects(int id)
        {
            Projects newProject = DBContext.Projects.First(x => x.Id == id);
            DBContext.Remove(newProject);
            DBContext.SaveChanges();
        }
        public ICollection<Projects> GetProjects()
        {
            return DBContext.Projects.ToHashSet();
        }
    }
    
}
