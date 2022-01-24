using System.ComponentModel.DataAnnotations;

namespace HomeWorkWeek9.Data.RecieveDataModels
{
    public class CreateUserModel
    {
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
        [Required]
        public int CompanyId { get; set; }
        [Required]

        public WeekDay Weekday { get; set; }

    }
}
