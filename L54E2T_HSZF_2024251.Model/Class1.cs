using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L54E2T_HSZF_2024251.Model
{
    public class WorkerRelationShip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Projects>? Projects { get; set; }
        public DateTime Reign_Start { get; set; }
        public DateTime Reign_End { get; set; }
        public WorkerRelationShip()
        {
            Projects = new HashSet<Projects>();
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
        public int WorkerValue { get; set; }
        public Projects()
        {
            Workers = new HashSet<Workers>();
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
    }
    public class WorkerRelationShip
    {
        
        [Key,Column(Order = 0)]
        [Required]
        public int WorkerId { get; set; }
        [Key, Column(Order = 0)]
        [Required]
        public int ManagerId { get; set; }
    }
}
