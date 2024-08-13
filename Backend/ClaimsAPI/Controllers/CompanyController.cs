using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClaimsAPI.Models.DTO.CompanyDTO;
using ClaimsAPI.Service.company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ClaimsAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompany _company;
        private readonly RequestTokenInfo _tokenInfo;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompany company, RequestTokenInfo tokenInfo, ILogger<CompanyController> logger)
        {
            this._company = company;
            _tokenInfo = tokenInfo;
            _logger = logger;
        }


        [HttpGet]
        
        public async Task<IActionResult> GetCompanies()
        {
            _logger.LogInformation($"GetCompanies called by UserId: {_tokenInfo.userId}, ClientId: {_tokenInfo.clientId}");
            var companies = await _company.GetCompanies(int.Parse(_tokenInfo.clientId));
            if (companies == null)
            {
                return NotFound();
            }
            return Ok(companies);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _company.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]

        public async Task<IActionResult> AddCompany(CompanyPostDTO company)
        {
            var Company = await _company.AddCompany(company, int.Parse(_tokenInfo.clientId));
            return Ok(company);
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> UpdateCompany(int id, CompanyUpdateDTO company)
        {
           
            var Company = await _company.UpdateCompany(id, company);
            if (Company == null)
            {
                return BadRequest("Company does not exist");
            }
            
            return Ok(Company);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _company.DeleteCompany(id);
            if (company == null)
            {
                return BadRequest();
            }
            
            return Ok(company);
        }
    }
}
