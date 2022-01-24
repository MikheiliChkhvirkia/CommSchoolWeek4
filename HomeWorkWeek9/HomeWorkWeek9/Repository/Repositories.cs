using HomeWorkWeek9.Data.CompanyEmplaySalaryCalculateModel;
using HomeWorkWeek9.Data.RecieveDataModels;
using HomeWorkWeek9.Data.SentDataModels;
using HomeWorkWeek9.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkWeek9.Repository
{
    public class Repositories : IRepository
    {
        private readonly HomeWorkDbContext context;

        public Repositories(
            HomeWorkDbContext context
            )
        {
            this.context = context;
        }

        public Respond CreateCompanies(AddCompanyModel model)
        {
            try
            {
                var company = new Company()
                {
                    Name = model.Name,
                    Foreign = model.Foreign
                };
                context.Companies.Add(company);
                context.SaveChanges();

            }
            catch (System.Exception)
            {

                return Respond.NotValidModel;
            }
            return Respond.Success;
        }

        public Respond CreatePossition(AddPossitionModel model)
        {
            try
            {
                var possition = new Possition()
                {
                    Name = model.Name,
                };
                context.Possitions.Add(possition);
                context.SaveChanges();

            }
            catch (System.Exception)
            {

                return Respond.NotValidModel;
            }
            return Respond.Success;
        }

        public Respond CreateUser(CreateUserModel model)
        {
            try
            {
                var workingHourCount = model.Weekday.Monday +
                                       model.Weekday.Tuesday +
                                       model.Weekday.Wednesday +
                                       model.Weekday.Thursday +
                                       model.Weekday.Friday;

                var weekendHourCount = model.Weekday.Saturday +
                                       model.Weekday.Sunday;

                var newUser = new Employ()
                {
                    PrivateId = model.PrivateId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    CompanyId = model.CompanyId,
                    PossitionId = model.PossitionId,
                    WeekDayWorkHour = workingHourCount,
                    WeekendWorkHour = weekendHourCount
                };

                context.Employs.Add(newUser);
                context.SaveChanges();

            }
            catch (System.Exception)
            {
                return Respond.NotValidModel;
            }
            return Respond.Success;
        }

        public IQueryable<GetCompaniesModel> GetCompanies()
        {
            return context.Companies.Select(x => new GetCompaniesModel()
            {
                Name = x.Name,
                Foreign = x.Foreign
            });
        }

        public IQueryable<GetPossitionModel> GetPossitions()
        {
            return context.Possitions.Select(x => new GetPossitionModel()
            {
                Name = x.Name
            });
        }

        public IQueryable<GetUsersModel> GetUsers()
        {
            return context.Employs.Select(x => new GetUsersModel()
            {
                Company = x.Company.Name,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
                Possition = x.Possition.Name,
                WeekDayWorkHour = x.WeekDayWorkHour,
                WeekendWorkHour = x.WeekendWorkHour
            });
            
        }

        public async Task<List<CompanyEmployerSalaryCalculateModel>> CalculateCompanyAndEmployer()
        {

            var test = await (from company in context.Companies
                              select new CompanyEmployerSalaryCalculateModel()
                              {
                                  CompanyId = company.Id,
                                  Company = company.Name,
                                  Employies = company.Employs.Count,
                                  Employer = new List<EmployiesModel>(),
                                  Foreign = company.Foreign,
                                  MustPayToGoverment = 1

                              }).ToListAsync();

            foreach (var item in test)
            {
                item.Employer = (from employ in context.Employs
                                 join company in context.Companies
                                 on employ.CompanyId equals company.Id
                                 where company.Id == item.CompanyId
                                 select new EmployiesModel()
                                 {
                                     EmployName = employ.FirstName,
                                     ThisWeekSalary = Salary(employ.Id)
                                     
                                 }).ToList();
            }

            return test;

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
                if (employ.WeekDayWorkHour + employ.WeekendWorkHour > 50)
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

            if (weekendHour > 0)
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
