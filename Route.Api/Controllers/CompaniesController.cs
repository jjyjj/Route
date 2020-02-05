using Microsoft.AspNetCore.Mvc;
using Route.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Route.Api.Controllers
{
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IComanyRepository _comanyRepository;
        //注入
        public CompaniesController(IComanyRepository comanyRepository)
        {
            _comanyRepository = comanyRepository ?? throw new ArgumentNullException(nameof(comanyRepository));
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _comanyRepository.GetCompaniesAsync();
            //序列化
            return new JsonResult(companies);
        }
    }
}
