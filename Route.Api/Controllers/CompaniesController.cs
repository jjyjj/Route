using Microsoft.AspNetCore.Mvc;
using Route.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Route.Api.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        //注入
        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository ??
                throw new ArgumentNullException(nameof(companyRepository));
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyRepository.GetCompaniesAsync();
            //序列化
            return Ok(companies);
        }
        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetCompanie(Guid companyId)
        {
            var company = await _companyRepository.GetCompanyAsync(companyId);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }
    }
}
