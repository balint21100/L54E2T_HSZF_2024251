using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Model
{
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
        public virtual ICollection<Workers> subWorkers { get; set; }
        public Workers()
        {
            subWorkers = new HashSet<Workers>();
        }
        public override string ToString()
        {
            return $"{Id} | {Name} | {Age} | {Type} | {ProjectId}";
        }
    }
}
