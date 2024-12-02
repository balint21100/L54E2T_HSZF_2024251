using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L54E2T_HSZF_2024251.Model
{
    public class Pharaohs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Projects>? Projects { get; set; }
        public DateTime Reign_Start { get; set; }
        public DateTime Reign_End { get; set; }
        public Pharaohs()
        {
            Projects = new List<Projects>();
        }
    }
    public class Projects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public int PharaoId { get; set; }
        public virtual List<Workers>? Workers { get; set; }
        public int WorkerCount { get { return Workers.Count(); } }
        public int WorkerValue { get; set; }
        public Projects()
        {
            Workers = new List<Workers>();
        }
    }
    public class Workers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
    }
    public class WorkerRelationShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int Manager { get; set; }
    }
}
