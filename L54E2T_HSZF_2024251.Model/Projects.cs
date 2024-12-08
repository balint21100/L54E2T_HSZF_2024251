using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Model
{
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
}
