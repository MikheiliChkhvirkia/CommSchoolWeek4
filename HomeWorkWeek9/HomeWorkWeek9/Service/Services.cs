using HomeWorkWeek9.Data.CompanyEmplaySalaryCalculateModel;
using HomeWorkWeek9.Data.RecieveDataModels;
using HomeWorkWeek9.Data.SentDataModels;
using HomeWorkWeek9.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkWeek9.Service
{
    public class Services : IService
    {
        private readonly IRepository repository;
        private readonly HomeWorkDbContext context;

        public Services(
            IRepository repository,
            HomeWorkDbContext context
            )
        {
            this.repository = repository;
            this.context = context;
        }

        public Respond CreateCompanies(AddCompanyModel model)
        {
            var findDublicate = context.Companies.FirstOrDefault(x => x.Name == model.Name);
            if (findDublicate == null)
            {
                return repository.CreateCompanies(model);
            }
            else
            {
                return Respond.DublicateCompany;
            }
        }

        public Respond CreatePossition(AddPossitionModel model)
        {
            var findDublicate = context.Possitions.FirstOrDefault(x => x.Name == model.Name);
            if (findDublicate == null)
            {
                return repository.CreatePossition(model);
            }
            else
            {
                return Respond.DublicatePossition;
            }
        }

        public Respond CreateUser(CreateUserModel model)
        {

            var findDublicate = context.Employs.FirstOrDefault(x => x.PrivateId == model.PrivateId);
            if (findDublicate == null)
            {
                return repository.CreateUser(model);
            }
            else
            {
                return Respond.DublicateEmploy;
            }
        }

        public IQueryable<GetCompaniesModel> GetCompanies()
        {
            return repository.GetCompanies();
        }

        public IQueryable<GetPossitionModel> GetPossitions()
        {
            return repository.GetPossitions();
        }

        public IQueryable<GetUsersModel> GetUsers()
        {
            return repository.GetUsers();
        }

        public async Task<List<CompanyEmployerSalaryCalculateModel>> CalculateCompanyAndEmployer()
        {
            return await repository.CalculateCompanyAndEmployer();
        }

        public int Salary(int id)
        {
            var employ = context.Employs.Where(x => x.Id == id).FirstOrDefault();

            int weekHour = 0,
                overTime = 0,
                weekEndHour = 0;

            int calc = 0;

            weekHour = employ.WeekDayWorkHour;
            weekEndHour = employ.WeekendWorkHour;
            if (employ.WeekDayWorkHour > 40)
            {
                overTime = weekHour - 40;
                weekHour -= overTime;
                if(employ.WeekDayWorkHour+employ.WeekendWorkHour>50)
                    calc = Calculate(overTime, weekHour, weekEndHour, employ, true);
                else
                    calc = Calculate(overTime, weekHour, weekEndHour, employ, false);

            }
            else
            {
                if (employ.WeekDayWorkHour + employ.WeekendWorkHour > 50)
                    calc = Calculate(overTime, weekHour, weekEndHour, employ, true);
                else
                    calc = Calculate(overTime, weekHour, weekEndHour, employ, false);
            }
            return calc;

        }

        public int Calculate(int overTime = 0, int weekHour = 0, int weekendHour = 0, Employ employ = null, bool bonus = false)
        {
            int result = 0;

            if (employ.PossitionId == 1)
                result += weekHour * 40;
            else if (employ.PossitionId == 2)
                result += weekHour * 30;
            else if (employ.PossitionId == 3)
                result += weekHour * 20;
            else
                result += weekHour * 10;

            if(weekendHour > 0)
            {
                if (employ.PossitionId == 1)
                    result += weekendHour * 80;
                else if (employ.PossitionId == 2)
                    result += weekendHour * 60;
                else if (employ.PossitionId == 3)
                    result += weekendHour * 40;
                else
                    result += weekendHour * 20;
            }

            result += overTime * 15;

            if (bonus)
            {
                result += result / 5;
            }

            return result;

        }
    }
}
