using HomeWorkWeek9.Data.CompanyEmplaySalaryCalculateModel;
using HomeWorkWeek9.Data.RecieveDataModels;
using HomeWorkWeek9.Data.SentDataModels;
using HomeWorkWeek9.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkWeek9.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IService service;

        public HomeController(
            IService service
            )
        {
            this.service = service;
        }

        #region Post
        [HttpPost("AddCompany")]
        public Respond AddCompany(AddCompanyModel model)
        {
            return service.CreateCompanies(model);
        }

        [HttpPost("AddPossition")]
        public Respond AddUsers(AddPossitionModel model)
        {
            return service.CreatePossition(model);
        }

        [HttpPost("AddUsers")]
        public Respond AddUsers(CreateUserModel model)
        {
            return service.CreateUser(model);
        }
        #endregion

        #region Get
        [HttpGet("GetUsers")]
        public IQueryable<GetUsersModel> GetUsers()
        {
            return service.GetUsers();
        }

        [HttpGet("GetCompanies")]
        public IQueryable<GetCompaniesModel> GetCompanies()
        {
            return service.GetCompanies();
        }

        [HttpGet("GetPossitions")]
        public IQueryable<GetPossitionModel> GetPossitions()
        {
            return service.GetPossitions();
        }
        #endregion

        #region GetWeekSalary

        [HttpGet("CalculateCompanyAndEmployer")]
        public async Task<List<CompanyEmployerSalaryCalculateModel>> CalculateCompanyAndEmployer()
        {
            return await service.CalculateCompanyAndEmployer();
        }

        #endregion


    }
}
