using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClaimsAPI.Models.DTO.CompanyDTO;
using ClaimsAPI.Service.company;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompany _company;

        public CompanyController(ICompany company)
        {
            this._company = company;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _company.GetCompanies();
            if (companies == null)
            {
                return NotFound();
            }
            return Ok(companies);
        }



        [HttpGet("getCarrier")]
        public async Task<IActionResult> GetCarrier(int clientid)
        {
            var carriers = await _company.GetCarrier(clientid);
            if (carriers == null)
            {
                return NotFound();
            }
            return Ok(carriers);
        }
        [HttpGet("getInsurance")]
        public async Task<IActionResult> GetInsurance(int clientid)
        {
            var carriers = await _company.GetInsurance(clientid);
            if (carriers == null)
            {
                return NotFound();
            }
            return Ok(carriers);
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
            var Company = await _company.AddCompany(company);
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