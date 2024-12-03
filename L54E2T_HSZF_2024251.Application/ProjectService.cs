using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Application
{
    public interface IProjectService
    {
        public Projects AddProjects(Projects oneProject);
        public void UpdateProjects(int id, Projects project);
        public void DeleteProjects(Projects projects);
        public ICollection<Projects> GetProjectsByFilter(Func<Projects, bool> filter);
        public ICollection<Projects> GetProjects();
    }
    public class ProjectService : IProjectService
    {
        private readonly IProjectDataProvider projectDataProvider;

        public ProjectService(IProjectDataProvider projectDataProvider)
        {
            this.projectDataProvider = projectDataProvider;
        }

        public Projects AddProjects(Projects oneProject)
        {
            return projectDataProvider.AddProjects(oneProject);
        }
        public void UpdateProjects(int id, Projects project)
        {
            projectDataProvider.UpdateProjects(id, project);
        }
        public void DeleteProjects(Projects projects)
        {
            projectDataProvider.DeleteProjects(projects.Id);
        }
        public ICollection<Projects> GetProjectsByFilter(Func<Projects, bool> filter)
        {
            return projectDataProvider.GetProjects().Where(filter).ToHashSet();
        }
        public ICollection<Projects> GetProjects()
        {
            return projectDataProvider.GetProjects();
        }
    }
}
