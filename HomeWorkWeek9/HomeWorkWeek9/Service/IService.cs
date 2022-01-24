using HomeWorkWeek9.Data.CompanyEmplaySalaryCalculateModel;
using HomeWorkWeek9.Data.RecieveDataModels;
using HomeWorkWeek9.Data.SentDataModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkWeek9.Service
{
    public interface IService
    {
        Respond CreateCompanies(AddCompanyModel model);
        Respond CreatePossition(AddPossitionModel model);
        Respond CreateUser(CreateUserModel model);
        IQueryable<GetUsersModel> GetUsers();
        IQueryable<GetCompaniesModel> GetCompanies();
        IQueryable<GetPossitionModel> GetPossitions();
        Task<List<CompanyEmployerSalaryCalculateModel>> CalculateCompanyAndEmployer();
        int Salary(int id);

    }
}
