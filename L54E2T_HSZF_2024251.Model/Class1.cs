using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L54E2T_HSZF_2024251.Model
{
    public class Pharaohs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Projects>? Projects { get; set; }
        public DateTime Reign_Start { get; set; }
        public DateTime Reign_End { get; set; }
        public Pharaohs()
        {
            Projects = new HashSet<Projects>();
        }
        public override string ToString()
        {
            return $"{Id} | {Name} | {Reign_Start.ToShortDateString()} | {Reign_End.ToShortDateString()}";
        }
    }
    public class Projects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Start_date { get; set; }
        [Required]
        public DateTime End_date { get; set; }
        [Required]
        public int PharaoId { get; set; }
        public virtual ICollection<Workers>? Workers { get; set; }
        public int WorkerCount { get { return Workers.Count(); } }
        public TimeSpan ProjectValue { get { return (End_date - Start_date) * WorkerCount / 2; } }
        public Projects()
        {
            Workers = new HashSet<Workers>();
        }
        public override string ToString()
        {
            return $"{Id} | {Name} | {Start_date.ToShortDateString()} | {End_date.ToShortDateString()} | {PharaoId}";
        }
    }
    public class Workers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public ICollection<Workers> subWorkers { get; set; }
        public Workers()
        {
            subWorkers = new HashSet<Workers>();
        }
        public override string ToString()
        {
            return $"{Id} | {Name} | {Age} | {Type} | {ProjectId}";
        }
    }
    
    public class WorkerRelationShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int WorkerId { get; set; }
        
        [Required]
        public int ManagerId { get; set; }
    }
}
