using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClaimsAPI.Models.DTO.CompanyTypeDTO;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypeController : ControllerBase
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;

        public CompanyTypeController(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }

        [HttpGet]
        public IActionResult GetCompanyTypes()
        {
            var companyType = shipmentClaimsContext.CompanyTypes.ToList();
            if (companyType == null)
            {
                return NotFound();
            }
            return Ok(companyType);
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetCompanyTypeById(int id)
        {
            var companyType = shipmentClaimsContext.CompanyTypes.Find(id);
            if (companyType == null)
            {
                return NotFound();
            }
            return Ok(companyType);
        }

        [HttpPost]

        public IActionResult AddCompany(CompanyTypePostDTO companyType)
        {
            var CompanyType = new CompanyType()
            {
                CompanyType1 = companyType.CompanyType1
            };
            shipmentClaimsContext.CompanyTypes.Add(CompanyType);
            shipmentClaimsContext.SaveChanges();
            return Ok(CompanyType);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult UpdateCompany(int id, CompanyTypeUpdateDTO companyType)
        {
            if (id != companyType.CompanyTypeId)
            {
                return BadRequest();
            }
            var CompanyType = shipmentClaimsContext.CompanyTypes.Find(id);
            if (CompanyType == null)
            {
                return BadRequest();
            }
            CompanyType.CompanyType1 = companyType.CompanyType1;
            shipmentClaimsContext.SaveChanges();
            return Ok(CompanyType);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteCompany(int id)
        {
            var companyType = shipmentClaimsContext.CompanyTypes.Find(id);
            if (companyType == null)
            {
                return BadRequest();
            }
            shipmentClaimsContext.CompanyTypes.Remove(companyType);
            shipmentClaimsContext.SaveChanges();
            return Ok(companyType);
        }
    }
}
