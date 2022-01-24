using System;
using System.ComponentModel.DataAnnotations;

namespace HomeWorkWeek9
{
    public class Employ
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PrivateId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        public int PossitionId { get; set; }
        public Possition Possition { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int WeekDayWorkHour { get; set; }
        public int WeekendWorkHour { get; set; }

        public bool? FetchedData { get; set; }
        public DateTime? LastFetchDate { get; set; }
    }
}
