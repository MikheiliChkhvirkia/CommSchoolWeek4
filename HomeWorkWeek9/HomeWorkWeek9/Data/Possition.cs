using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeWorkWeek9
{
    public class Possition
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ICollection<Employ> Employs { get; set; }
    }
}
