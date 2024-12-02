using L54E2T_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Serialization;

namespace L54E2T_HSZF_2024251.Persistence.MsSql
{
    //database
    public class EgyptDb : DbContext
    {
        
        public DbSet<Pharaohs> Pharaohs { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<WorkerRelationShip> WorkerRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharaohs>().HasKey(b => b.Id);
            modelBuilder.Entity<Workers>().HasKey(b => b.Id);
            modelBuilder.Entity<Projects>().HasKey(b => b.Id);
            modelBuilder.Entity<WorkerRelationShip>().HasKey(b => b.Id);
        }
        public EgyptDb()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            Load();
            SaveChanges();
            Thread.Sleep(2000);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EgyptDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        [XmlRoot("Data")]
        public class Data
        {
            [XmlArray("Pharaohs")]
            [XmlArrayItem("Pharaoh")]
            public List<Pharaohs> Pharaohs { get; set; }

            [XmlArray("Workers")]
            [XmlArrayItem("Worker")]
            public List<Workers> Workers { get; set; }

            [XmlArray("WorkerRelationShips")]
            [XmlArrayItem("WorkerRelationShip")]
            public List<WorkerRelationShip> WorkerRelationShips { get; set; }
        }
        public void Load()
        {
            
            
            string filePath = "Seed.xml"; 
            
            Data data = LoadDataFromXml(filePath);

            if (data != null)
            {
                
                foreach (var pharaoh in data.Pharaohs)
                {
                    
                    Pharaohs.Add(pharaoh);

                    
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
