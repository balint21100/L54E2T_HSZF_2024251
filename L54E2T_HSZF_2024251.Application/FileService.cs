using L54E2T_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static L54E2T_HSZF_2024251.Persistence.MsSql.EgyptDb;
using System.Xml.Serialization;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace L54E2T_HSZF_2024251.Application
{
    public interface IFileService
    {
        public void Import(string filepath);
    }
    public class FileService : IFileService
    {
        private readonly IPharaohDataProvider pharaohDataProvider;
        private readonly IProjectDataProvider projectDataProvider;
        private readonly IWorkerDataProvider workerDataProvider;
        private readonly IWorkerRelationshipsDataProvider workerRelationshipsDataProvider;

        public FileService(IPharaohDataProvider pharaohDataProvider, IProjectDataProvider projectDataProvider, IWorkerDataProvider workerDataProvider, IWorkerRelationshipsDataProvider workerRelationshipsDataProvider)
        {
            this.pharaohDataProvider = pharaohDataProvider;
            this.projectDataProvider = projectDataProvider;
            this.workerDataProvider = workerDataProvider;
            this.workerRelationshipsDataProvider = workerRelationshipsDataProvider;
        }

        public void Import(string filepath)
        {
            JObject root = JObject.Parse(File.ReadAllText(filepath));

            if (root["Pharaohs"] == null)
            {
                throw new ArgumentException("Pharaohs are missing");
            }
            JArray pharaohsjsons = JArray.Parse(root["Pharaohs"]!.ToString());
            foreach (var pharaohjson in pharaohsjsons)
            {
                Pharaohs pharaoh = JsonConvert.DeserializeObject<Pharaohs>(pharaohjson.ToString());
                Pharaohs newpharaoh = pharaohDataProvider.AddPharaoh(new Pharaohs()
                {
                    Name = pharaoh.Name,
                    Reign_Start = pharaoh.Reign_Start,
                    Reign_End = pharaoh.Reign_End
                });
                if (pharaohjson["Projects"] == null)
                {
                    throw new ArgumentException("Projects are missing");
                }
                JArray projectsjsons = JArray.Parse(pharaohjson["Projects"]!.ToString());
                foreach(var projectjson in projectsjsons)
                {
                    Projects project = JsonConvert.DeserializeObject<Projects>(projectjson.ToString());
                    Projects newproject = projectDataProvider.AddProjects(new Projects()
                    {
                        Name = project.Name,
                        Start_date = project.Start_date,
                        End_date = project.End_date,
                        PharaoId = newpharaoh.Id
                    });
                    if (projectjson["Workers"] == null)
                    {
                        throw new ArgumentException("Workers are missing");
                    }
                    JArray workerjsons = JArray.Parse(projectjson["Workers"]!.ToString());
                    foreach (var workerjson in workerjsons)
                    {
                        Workers worker = JsonConvert.DeserializeObject<Workers>(workerjson.ToString());
                        Workers newworker = workerDataProvider.AddWorker(new Workers()
                        {
                            Name = worker.Name,
                            Age = worker.Age,
                            Type = worker.Type,
                            ProjectId = newproject.Id
                        });
                        SubWorkerAdd(workerjson, newworker.Id, newproject.Id);
                    }
                }
            }
            
        }
        private void SubWorkerAdd(JToken workerjson, int newworkerid, int newprojectid)
        {
            JArray subworkerjsons = JArray.Parse(workerjson["SubWorkers"]!.ToString());
            foreach (var subworkerjson in subworkerjsons)
            {
                Workers subworker = JsonConvert.DeserializeObject<Workers>(subworkerjson.ToString());
                Workers newsubworker = workerDataProvider.AddWorker(new Workers()
                {
                    Name = subworker.Name,
                    Age = subworker.Age,
                    Type = subworker.Type,
                    ProjectId = newprojectid
                });
                WorkerRelationShip workerRelationShip = workerRelationshipsDataProvider.AddWorkerRelationships(new WorkerRelationShip()
                {
                    ManagerId = newworkerid,
                    WorkerId = newsubworker.Id
                });
                SubWorkerAdd(subworkerjson, newsubworker.Id, newprojectid);
            }
        }
    }

}
