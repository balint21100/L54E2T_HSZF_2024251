using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
