using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Application
{
    public interface IDataService
    {
        public bool AddProPah(string[] ProjectOrPharao, string choice);
        public int Check(string input, string type, ref string error);
        public bool DeleteWorkers(Workers worker);
        public Workers[]? SearchWorkerBy(string choice, string answer);
        public void CFolder();
        public string[] GetPharaohs();
        public string[] GetProjects();
        public string[] SearchForWorkerTypes(string type);
        public void GetReport();

    }
    public class DataService : IDataService
    {
        IPahraohDataProvider pahraohDataProvider;
        IProjectDataProvider projectDataProvider;
        IWorkerDataProvider workerDataProvider;
        IReport report;

        public DataService(IPahraohDataProvider pahraohDataProvider, IProjectDataProvider projectDataProvider, IWorkerDataProvider workerDataProvider, IReport report)
        {
            this.pahraohDataProvider = pahraohDataProvider;
            this.projectDataProvider = projectDataProvider;
            this.workerDataProvider = workerDataProvider;
            this.report = report;
        }
        public void GetReport()
        {
            report.GenerateAndExportPharaohReports();
            report.GenerateAllReports();
            
        }

        public bool AddProPah(string[] ProjectOrWorker, string choice)
        {
            if (choice == "Worker")
            {
                Workers workers = new Workers();
                workers.Name = ProjectOrWorker[0];
                workers.Age = Convert.ToInt32(ProjectOrWorker[1]);
                workers.Type = ProjectOrWorker[2];
                return workerDataProvider.AddWorker(workers);
            }
            else if (choice == "Project")
            {
                Projects project = new Projects();
                project.Name = ProjectOrWorker[0];
                project.Start_date = Convert.ToDateTime(ProjectOrWorker[1]);
                project.End_date = Convert.ToDateTime(ProjectOrWorker[2]);
                return projectDataProvider.AddProject(project);
            }
            return false;
        }
        public bool DeleteWorkers(Workers worker)
        {
            return workerDataProvider.DeleteWorkerFrominDB(worker);
        }

        public int Check(string input, string type, ref string error)
        {
            if (type == null)
            {
                throw new ArgumentNullException("input");
            }
            else if (type == "age")
            {
                return AgeCheck(input, ref error);
            }
            else if (type == "date")
            {
                return DateChecker(input, ref error);
            }
            else if (type == "int")
            {
                return IntChecker(input, ref error);
            }
            else if (type == "string")
            {
                if (input == string.Empty)
                {
                    return -1;
                }
                return 1;
            }
            else
            {
                return 1;
            }
        }
        public Workers[]? SearchWorkerBy(string choice, string answer)
        {
            if (choice == "Id")
            {
                return workerDataProvider.SearchWorkerByIdInDB(Convert.ToInt32(answer));
            }
            else if (choice == "Name")
            {
                return workerDataProvider.SearchWorkerByNameInDB(answer);
            }
            else if (choice == "Age")
            {
                return workerDataProvider.SearchWorkerByAgeInDB(Convert.ToInt32(answer));
            }
            else if (choice == "Type")
            {
                return workerDataProvider.SearchWorkerByTypeInDB(answer);
            }
            return null;
        }
        public string[] SearchForWorkerTypes(string type)
        {
            List < Projects > projects = projectDataProvider.ProjectsName(type);
            List<string> projects2 = new List<string>();
            foreach (var item in projects)
            {
                string oneprojec = $"project name: {item.Name} project Starting Date:{item.Start_date} project workers on this: {item.Workers.Count}";
                projects2.Add(oneprojec);
            }
            return projects2.ToArray();

        }
        public string[] GetPharaohs()
        {
            return pahraohDataProvider.GetPharaohs();
        }
        public string[] GetProjects()
        {
            return projectDataProvider.GetProjects();
        }
        int AgeCheck(string input, ref string error)
        {
            int result;
            int age = 0;
            result = IntChecker(input, ref error);

            if (result == 1)
            {
                age = Convert.ToInt32(input);
                if (age > 0 && age < 60)
                {
                    return 1;
                }
                else
                {
                    error = "The worker is too old";
                    return -1;
                }
            }
            else
            {
                return -1;
            }

        }

       int IntChecker(string input, ref string error)
        {
            int result;
            try
            {
                result = int.Parse(input);
            }
            catch (Exception)
            {
                error = "Enter only numbers";
                return -1;
            }
            return 1;
        }

       int DateChecker(string i, ref string error)
        {
            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(i);
            }
            catch (Exception)
            {
                error = "The date was not in a correct format, The correct format: YYYY.MM.DD";
                return -1;
            }
            return 1;
        }
        public void CFolder()
        {
            if (!Directory.Exists("Projects"))
            {
                Directory.CreateDirectory("Projects");
            }
            int[] pahraoh = pahraohDataProvider.GetPharaohId();
            for (int i = 0; i < pahraoh.Length; i++)
            {
                CreatePharaohProjectDirectory(pahraoh[i]);
            }
        }
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
