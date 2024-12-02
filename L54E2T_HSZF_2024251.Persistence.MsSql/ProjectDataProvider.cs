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
        public List<Projects> ProjectsName(string workers);



        public Projects AddProjects(Projects onePharaoh);
        public void UpdateProjects(int id, Projects pharaohs);
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
        public bool AddProject(Projects project)
        {
            DBContext.Projects.Add(project);
            DBContext.SaveChanges();
            return true;
        }
        //public string[] GetProjects()
        //{
        //    Projects[] project = DBContext.Projects.Select(x => x).ToArray();
        //    List<string> projectslist = new List<string>();
        //    foreach (var item in project)
        //    {
        //        string s = $"{item.Id} {item.Name} {item.Start_date} {item.End_date} {item.PharaoId}";
        //        projectslist.Add(s);
        //    }
        //    return projectslist.ToArray();
        //}
        public List<Projects> ProjectsName(string workers)
        {
            var projectsWithWorkerType = DBContext.Projects
                                                .Where(p => p.Workers.Any(w => w.Type == workers))
                                                .Include(p => p.Workers)
                                                .ToList();
            return projectsWithWorkerType;
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
