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
        private readonly IPharaohDataProvider pharaohDataProvider;

        public ProjectService(IProjectDataProvider projectDataProvider, IPharaohDataProvider pharaohDataProvider)
        {
            this.projectDataProvider = projectDataProvider;
            this.pharaohDataProvider = pharaohDataProvider;
        }

        public Projects AddProjects(Projects oneProject)
        {
            if (oneProject.Start_date > oneProject.End_date)
            {
                throw new ArgumentException("Error! The start date is must be before the end date.");
            }
            if (!pharaohDataProvider.GetPharaohs().Any(x => x.Id == oneProject.PharaoId))
            {
                throw new ArgumentException("Error! Pharaoh not found.");
            }
            return projectDataProvider.AddProjects(oneProject);
        }
        public void UpdateProjects(int id, Projects project)
        {
            if (project.Start_date > project.End_date)
            {
                throw new ArgumentException("Error! The start date is must be before the end date.");
            }
            if (!pharaohDataProvider.GetPharaohs().Any(x => x.Id == project.PharaoId))
            {
                throw new ArgumentException("Error! Pharaoh not found.");
            }
            projectDataProvider.UpdateProjects(id, project);
        }
        public void DeleteProjects(Projects projects)
        {
            if (projects == null)
            {
                throw new ArgumentException("Project not found");
            }
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
