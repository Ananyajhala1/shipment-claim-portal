using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClaimsAPI.Models.DTO.CompanyTypeDTO;
using ClaimsAPI.Service.CompanyTypeService;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypeController : ControllerBase
    {
        private readonly ICompanyTypeService _companyTypeService;
        public CompanyTypeController(ICompanyTypeService companyTypeService)
        {
            _companyTypeService = companyTypeService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyType>>> GetCompanyTypes()
        {
            var CompanyTypeService = await _companyTypeService.GetCompanyTypes();
            if(CompanyTypeService == null)
            {
                return NotFound();
            }
            return Ok(CompanyTypeService);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<CompanyType>> GetCompanyTypeById(int id)
        {
            var companyType = await _companyTypeService.GetCompanyTypeById(id);
            if(companyType == null)
            {
                return NotFound();
            }
            return Ok(companyType);
        }
        [HttpPost]
        public async Task<ActionResult<CompanyType>> AddCompany(CompanyTypePostDTO companyType)
        {
            var CompanyType = await _companyTypeService.AddCompany(companyType);
            return Ok(CompanyType);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<CompanyType>> UpdateCompany(int id, CompanyTypeUpdateDTO companyType)
        {
            var CompanyType = await _companyTypeService.UpdateCompany(id, companyType);

            if(companyType.CompanyTypeId != id)
            {
                return BadRequest();
            }
            if(CompanyType == null)
            {
                return NotFound();
            }
            return Ok(CompanyType);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<CompanyType>> DeleteCompany(int id)
        {
            var companyType = await _companyTypeService.DeleteCompany(id);
            if(companyType == null)
            {
                return NotFound();
            }
            return Ok(companyType);
        }

    }
}
