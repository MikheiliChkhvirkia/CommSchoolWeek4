using System.Collections.Generic;
using System.Linq;

namespace HomeWorkWeek9.Data.CompanyEmplaySalaryCalculateModel
{
    public class CompanyEmployerSalaryCalculateModel
    {
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public int Employies { get; set; }

        public IList<EmployiesModel> Employer { get; set; }
        public int AverageSalary { get; set; }
        public bool Foreign { get; set; }
        public int MustPayToGoverment { get; set; }
    }
}
