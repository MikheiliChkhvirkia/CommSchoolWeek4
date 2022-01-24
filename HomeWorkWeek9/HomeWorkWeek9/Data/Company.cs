using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HomeWorkWeek9
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Foreign { get; set; }
        public ICollection<Employ> Employs { get; set; }
    }
}
