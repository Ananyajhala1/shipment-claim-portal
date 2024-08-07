using ClaimsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClaimsAPI.Models.DTO.Claims;
using ClaimsAPI.Models.Entites;
using System.Threading;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        private readonly RequestTokenInfo _requestTokenInfo;

        public ClaimsController(ShipmentClaimsContext shipmentClaimsContext, RequestTokenInfo requestTokenInfo)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
            this._requestTokenInfo = requestTokenInfo;
        }

        [HttpGet]
        public IActionResult GetClaims()
        {
            var claims = shipmentClaimsContext.Claims.ToList();
            if (claims == null)
            {
                return NotFound();
            }
            return Ok(claims);
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetCompanyTypeById(int id)
        {   



            var claim = shipmentClaimsContext.Claims.Find(id);
            if (claim == null)
            {
                return NotFound();
            }
            return Ok(claim);
        }

        [HttpPost]

        public IActionResult AddCompany(ClaimPostDTO claim)
        {
            var Claim = new Claim()
            {
                FileDate = claim.FileDate,
                CustomerId = claim.CustomerId,
                CarrierId = claim.CarrierId,
                InsuranceId = claim.InsuranceId,
                Carrier = claim.Carrier,
                ClaimDocuments = claim.ClaimDocuments,
                ClaimSettings = claim.ClaimSettings,
                ClaimStatuses = claim.ClaimStatuses,
                ClaimTasks = claim.ClaimTasks,
                Customer = claim.Customer,
                Insurance = claim.Insurance
            };
            shipmentClaimsContext.Claims.Add(Claim);
            shipmentClaimsContext.SaveChanges();
            return Ok(Claim);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult UpdateCompany(int id, ClaimUpdateDTO claim)
        {
            if (id != claim.ClaimId)
            {
                return BadRequest();
            }
            var Claim = shipmentClaimsContext.Claims.Find(id);
            if (Claim == null)
            {
                return BadRequest();
            }

            Claim.ClaimDocuments = claim.ClaimDocuments;
            Claim.ClaimSettings = claim.ClaimSettings;
            Claim.ClaimStatuses = claim.ClaimStatuses;
            Claim.ClaimTasks = claim.ClaimTasks;
            shipmentClaimsContext.SaveChanges();
            return Ok(Claim);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteCompany(int id)
        {
            var claim = shipmentClaimsContext.Claims.Find(id);
            if (claim == null)
            {
                return BadRequest();
            }
            shipmentClaimsContext.Claims.Remove(claim);
            shipmentClaimsContext.SaveChanges();
            return Ok(claim);
        }
    }
}
