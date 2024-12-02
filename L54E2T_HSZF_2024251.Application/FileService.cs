using L54E2T_HSZF_2024251.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static L54E2T_HSZF_2024251.Persistence.MsSql.EgyptDb;
using System.Xml.Serialization;

namespace L54E2T_HSZF_2024251.Application
{
    public interface IFileService
    {

    }
    [XmlRoot("Data")]
    public class Data
    {
        [XmlArray("WorkerRelationShip")]
        [XmlArrayItem("Pharaoh")]
        public List<WorkerRelationShip> Pharaohs { get; set; }

        [XmlArray("Workers")]
        [XmlArrayItem("Worker")]
        public List<Workers> Workers { get; set; }

        [XmlArray("WorkerRelationShips")]
        [XmlArrayItem("WorkerRelationShip")]
        public List<WorkerRelationShip> WorkerRelationShips { get; set; }
    }
    public class FileService
    {
        public void Import(string filePath)
        {


            

            Data data = LoadDataFromXml(filePath);

            if (data != null)
            {

                foreach (var pharaoh in data.Pharaohs)
                {

                    WorkerRelationShip.Add(pharaoh);


                    foreach (var project in pharaoh.Projects)
                    {
                        Projects.Add(project);


                        foreach (var worker in project.Workers)
                        {
                            Workers.Add(worker);
                        }
                    }
                }


                foreach (var relationship in data.WorkerRelationShips)
                {
                    WorkerRelations.Add(relationship);
                }




                Console.WriteLine("Adatok sikeresen betöltve az adatbázisba.");
            }
            else
            {
                Console.WriteLine("A fájl betöltése nem sikerült.");
            }
        }



        static Data LoadDataFromXml(string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Data));


                using (var reader = new StreamReader(filePath))
                {
                    return (Data)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt az XML fájl betöltése során: {ex.Message}");
                return null;
            }
        }
    }
}
