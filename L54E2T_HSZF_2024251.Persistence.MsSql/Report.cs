using L54E2T_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace L54E2T_HSZF_2024251.Persistence.MsSql
{
    public interface IReport
    {
        public WorkerRelationShip? GeneratePharaohReport(int pharaohId);
        public void Reports();
        public void GenerateAndExportPharaohReports();
        public void GenerateAllReports();
    }
    public class Report : IReport
    {
        private readonly EgyptDb DBContext;
        public Report( EgyptDb Db)
        {
            DBContext = Db;
        }
        public void ReportsAboutWorkerByAge()
        {
            
            var groups = DBContext.Workers.ToList().GroupBy(x =>
            {
                if (x.Age >= 0 && x.Age <= 10) return "Workers Between 0-10";
                else if (x.Age >= 11 && x.Age <= 20) return "Workers Between 11-20";
                else if (x.Age >= 21 && x.Age <= 30) return "Workers Between 21-30";
                else if (x.Age >= 31 && x.Age <= 40) return "Workers Between 31-40";
                else if (x.Age >= 41 && x.Age <= 50) return "Workers Between 41-50";
                else if (x.Age >= 51 && x.Age <= 60) return "Workers Between 51-60";
                else return " ";
            });

            //File.WriteAllLines("Report about workers by age", );
            
        }
        public WorkerRelationShip? GeneratePharaohReport(int pharaohId)
        {
            // Lekérdezés a fáraóra és projektjeire
            var pharaoh = DBContext.Pharaohs
                .Include(p => p.Projects)
                .ThenInclude(pr => pr.Workers)
                .FirstOrDefault(p => p.Id == pharaohId);
            return pharaoh;
        }
        public void Reports()
        {
            
                // Lekérdezzük a fáraókat és az ő projektjeiket
                var pharaohsWithProjects = DBContext.Pharaohs
                                                  .Include(p => p.Projects)
                                                  .ThenInclude(p => p.Workers)
                                                  .ToList();

                // Minden fáraóhoz készítünk egy riportot
                foreach (var pharaoh in pharaohsWithProjects)
                {
                    var projectReport = new PharaohProjectReport
                    {
                        PharaohName = pharaoh.Name,
                        Projects = new List<ProjectDetails>()
                    };

                    // Minden projekt adatait lekérjük a fáraóhoz
                    foreach (var project in pharaoh.Projects)
                    {
                        // Munkások száma
                        int workersCount = project.Workers?.Count ?? 0;

                        // Munkaórák számítása (pl. 8 órás munkanapokkal számolva)
                        int totalWorkHours = workersCount * (int)(project.End_date - project.Start_date).TotalDays * 8;

                        // A projekt adatai
                        projectReport.Projects.Add(new ProjectDetails
                        {
                            ProjectName = project.Name,
                            StartDate = project.Start_date,
                            EndDate = project.End_date,
                            WorkersCount = workersCount,
                            TotalWorkHours = totalWorkHours
                        });
                    }

                    // Mappát hozunk létre a fáraó számára
                    string directoryPath = Path.Combine("Project", pharaoh.Name);
                    Directory.CreateDirectory(directoryPath);

                    // Fájl elérési út
                    string filePath = Path.Combine(directoryPath, $"Pharaoh{pharaoh.Id}");

                    // XML fájl mentése
                    var serializer = new XmlSerializer(typeof(PharaohProjectReport));
                    using (var writer = new StreamWriter(filePath))
                    {
                        serializer.Serialize(writer, projectReport);
                    }

                    Console.WriteLine($"Report for Pharaoh {pharaoh.Name} saved to {filePath}");
                }
            
        }
        // Riport adatstruktúrák
        [XmlRoot("PharaohProjectReport")]
        public class PharaohProjectReport
        {
            [XmlElement("PharaohName")]
            public string PharaohName { get; set; }

            [XmlArray("Projects")]
            [XmlArrayItem("Project")]
            public List<ProjectDetails> Projects { get; set; }
        }

        public class ProjectDetails
        {
            [XmlElement("ProjectName")]
            public string ProjectName { get; set; }

            [XmlElement("StartDate")]
            public DateTime StartDate { get; set; }

            [XmlElement("EndDate")]
            public DateTime EndDate { get; set; }

            [XmlElement("WorkersCount")]
            public int WorkersCount { get; set; }

            [XmlElement("TotalWorkHours")]
            public int TotalWorkHours { get; set; }
        }

        

        public void ExportReportsToXml(List<WorkerRelationShip> reports)
        {
            // Alapértelmezett mappa a fáraók riportjainak
            string baseDirectory = "Projects/";

            // Ellenőrizzük, hogy létezik-e a mappa
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }

            // Mentsük el a fáraók riportjait fáraó ID alapján
            foreach (var report in reports)
            {
                // Mappa és fájl név: "Reports/Pharaoh_{PharaohId}/"
                string pharaohDirectory = Path.Combine(baseDirectory, $"Pharaoh_{report.Id}");

                // Mappa létrehozása fáraónként
                if (!Directory.Exists(pharaohDirectory))
                {
                    Directory.CreateDirectory(pharaohDirectory);
                }

                // Fájl elmentése XML formátumban
                string filePath = Path.Combine(pharaohDirectory, $"Pharaoh{report.Id}");

                var serializer = new XmlSerializer(typeof(WorkerRelationShip));
                using (var writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, report);
                }
            }
        }
        public void GenerateAndExportPharaohReports()
        {
            // Lekérjük az adatokat az adatbázisból (itt csak példa lekérdezés)
            var pharaohReports = DBContext.Pharaohs
                .Select(pharaoh => new WorkerRelationShip
                {
                    Name = pharaoh.Name,
                    Reign_Start = pharaoh.Reign_Start,
                    Reign_End = pharaoh.Reign_End,
                    Projects = pharaoh.Projects.Select(project => new Projects
                    {
                        Name = project.Name,
                        Start_date = project.Start_date,
                        End_date = project.End_date,
                        WorkerCount = project.Workers.Count(),
                        WorkerValue = project.Workers.Sum(worker => worker.Age * 100) // Példa érték, életkor alapján
                    }).ToList()
                }).ToList();

            // Riportok mentése XML fájlba
            ExportReportsToXml(pharaohReports);
        }

        public void GenerateAndExportPharaohReport()
        {
            // Lekérdezzük az összes fáraót és az uralkodásuk dátumait
            var pharaohs = DBContext.Pharaohs
                .Select(pharaoh => new WorkerRelationShip
                {
                    Name = pharaoh.Name,
                    Reign_Start = pharaoh.Reign_Start,
                    Reign_End = pharaoh.Reign_End
                })
                .ToList();

            // Exportálás XML fájlba
            ExportPharaohReportToXml(pharaohs);
        }

        public void ExportPharaohReportToXml(List<WorkerRelationShip> reports)
        {
            var serializer = new XmlSerializer(typeof(List<WorkerRelationShip>));
            using (var writer = new StreamWriter("PharaohReport.xml"))
            {
                serializer.Serialize(writer, reports);
            }
        }
        public void GenerateAndExportAgeGroupReport()
        {
            var ageGroups = DBContext.Workers
        .GroupBy(worker => worker.Age / 10)  // Életkor alapján csoportosítás
        .Select(group => new AgeGroupReport
        {
            AgeRange = $"{group.Key * 10}-{(group.Key + 1) * 10 - 1}",
            WorkerCount = group.Count()  // Csoportonkénti számolás
        })
        .OrderBy(group => group.AgeRange)  // Életkor szerint rendezés
        .ToList();

            ExportAgeGroupReportToXml(ageGroups);
        }

        public void ExportAgeGroupReportToXml(List<AgeGroupReport> reports)
        {
            var serializer = new XmlSerializer(typeof(List<AgeGroupReport>));
            using (var writer = new StreamWriter("AgeGroupReport.xml"))
            {
                serializer.Serialize(writer, reports);
            }
        }

        public class AgeGroupReport
        {
            public string AgeRange { get; set; }
            public int WorkerCount { get; set; }
        }
        public void GenerateAllReports()
        {
            // Riportok generálása
            GenerateAndExportPharaohReport();
            GenerateAndExportAgeGroupReport();

            Console.WriteLine("Riportok sikeresen generálva.");
        }
    }
}
