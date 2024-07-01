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
        public IActionResult GetCompanyTypes()
        {
            var CompanyTypeService = _companyTypeService.GetCompanyTypes();
            if(CompanyTypeService == null)
            {
                return NotFound();
            }
            return Ok(CompanyTypeService);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCompanyTypeById(int id)
        {
            var companyType = _companyTypeService.GetCompanyTypeById(id);
            if(companyType == null)
            {
                return NotFound();
            }
            return Ok(companyType);
        }
        [HttpPost]
        public IActionResult AddCompany(CompanyTypePostDTO companyType)
        {
            var CompanyType = _companyTypeService.AddCompany(companyType);
            return Ok(CompanyType);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCompany(int id, CompanyTypeUpdateDTO companyType)
        {
            var CompanyType = _companyTypeService.UpdateCompany(id, companyType);

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
        public IActionResult DeleteCompany(int id)
        {
            var companyType = _companyTypeService.DeleteCompany(id);
            if(companyType == null)
            {
                return NotFound();
            }
            return Ok(companyType);
        }

    }
}
