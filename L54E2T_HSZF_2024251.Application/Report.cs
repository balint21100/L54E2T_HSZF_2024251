using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace L54E2T_HSZF_2024251.Application
{
    [XmlRoot("PharaohReport")]
    public class PharaohReport
    {
        [XmlElement("PharaohName")]
        public string PharaohName { get; set; }

        [XmlArray("Projects")]
        [XmlArrayItem("Project")]
        public List<ProjectReport> Projects { get; set; }
    }

    public class ProjectReport
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkersCount { get; set; }
        public int TotalWorkHours { get; set; }
    }
    public interface IReportinApplication
    {
        public void GeneratePharaohReport(int pharaohId);
    }
    public class ReportinApplication
    {
        IReport report;
        public ReportinApplication(IReport report)
        {
            this.report = report;
        }
        public void SavePharaohReport(PharaohReport report, int pharaohId)
        {
            var serializer = new XmlSerializer(typeof(PharaohReport));

            // Fő mappa neve: Projects
            string rootDirectory = "Projects";

            // Almappa neve a fáraó azonosítója alapján
            string pharaohDirectory = Path.Combine(rootDirectory, $"Pharaoh_{pharaohId}");

            // Ellenőrizzük, hogy létezik-e a mappa, ha nem, létrehozzuk
            if (!Directory.Exists(pharaohDirectory))
            {
                Directory.CreateDirectory(pharaohDirectory);
            }

            // XML fájl neve és elérési útja
            var filePath = Path.Combine(pharaohDirectory, "PharaohProjects.xml");

            // Fájl írása
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, report);
            }
        }
        public void CreatePharaohProjectDirectory(int pharaohId)
        {
            // Fő mappa neve: Projects
            string rootDirectory = "Projects";

            // Almappa neve a fáraó azonosítója alapján
            string pharaohDirectory = Path.Combine(rootDirectory, $"Pharaoh_{pharaohId}");

            // Ellenőrizzük, hogy létezik-e a mappa, ha nem, létrehozzuk
            if (!Directory.Exists(pharaohDirectory))
            {
                Directory.CreateDirectory(pharaohDirectory);
            }
        }
        public void GeneratePharaohReport(int pharaohId)
        {
            Pharaohs? pharaoh = report.GeneratePharaohReport(pharaohId);

            if (pharaoh != null)
            {
                // Riport adatok előkészítése
                var report = new PharaohReport
                {
                    PharaohName = pharaoh.Name,
                    Projects = pharaoh.Projects.Select(pr => new ProjectReport
                    {
                        ProjectName = pr.Name,
                        StartDate = pr.Start_date,
                        EndDate = pr.End_date,
                        WorkersCount = pr.Workers.Count
                    }).ToList()
                };

                // Mappa létrehozása a fáraó azonosítója szerint
                CreatePharaohProjectDirectory(pharaohId);

                // Riport mentése a megfelelő mappába
                SavePharaohReport(report, pharaohId);
            }
        }

        //public void Workersasa()
        //{
        //    using (var context = new MyDbContext())
        //    {
        //        var pharaohsWithProjects = context.Pharaohs
        //                                          .Include(p => p.Projects)
        //                                          .ThenInclude(p => p.Workers)
        //                                          .ToList();

        //        foreach (var pharaoh in pharaohsWithProjects)
        //        {
        //            // Készítjük el a fáraó projekthez tartozó riportot
        //            var projectReport = new ProjectReport
        //            {
        //                PharaohName = pharaoh.Name,
        //                Projects = new List<ProjectDetails>()
        //            };

        //            foreach (var project in pharaoh.Projects)
        //            {
        //                // A projektben lévő munkások száma
        //                int workersCount = project.Workers?.Count ?? 0;

        //                // Munkaórák számítása (itt feltételezünk egy átlagos napi munkaórát, pl. 8 óra/nap)
        //                int totalWorkHours = workersCount * (int)(project.End_date - project.Start_date).TotalDays * 8;

        //                // Projekt adatok hozzáadása
        //                projectReport.Projects.Add(new ProjectDetails
        //                {
        //                    ProjectName = project.Name,
        //                    StartDate = project.Start_date,
        //                    EndDate = project.End_date,
        //                    WorkersCount = workersCount,
        //                    TotalWorkHours = totalWorkHours
        //                });
        //            }

        //            // Fájl mentése a fáraó saját mappájába
        //            string directoryPath = Path.Combine("Reports", pharaoh.Name);
        //            Directory.CreateDirectory(directoryPath);

        //            string filePath = Path.Combine(directoryPath, $"{pharaoh.Name}_project_report.xml");

        //            // XML fájl létrehozása
        //            var serializer = new XmlSerializer(typeof(ProjectReport));
        //            using (var writer = new StreamWriter(filePath))
        //            {
        //                serializer.Serialize(writer, projectReport);
        //            }

        //            Console.WriteLine($"Report for Pharaoh {pharaoh.Name} saved to {filePath}");
        //        }

        




    }

    
}
