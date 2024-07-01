using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.ClaimSettingsDTO;
using ClaimsAPI.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Security.Claims;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimSettingsController : ControllerBase
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;

        public ClaimSettingsController(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }

        [HttpGet]
        public IActionResult GetClaimSettings()
        {
            var claimSettings = shipmentClaimsContext.ClaimSettings.ToList();
            if(claimSettings == null)
            {
                return BadRequest();
            }
            return Ok(claimSettings);
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetClaimSettingById(int id)
        {
            var claimSetting = shipmentClaimsContext.ClaimSettings.Find(id);
            if(claimSetting == null)
            {
                return BadRequest();
            }
            return Ok(claimSetting);
        }

        [HttpPost]

        public IActionResult PostClaimSetting(ClaimSettingsPostDTO claimSetting)
        {
            var claimsetting = new ClaimSetting()
            {
                ClaimId = claimSetting.ClaimId,
                CompanyId = claimSetting.CompanyId,
                DocId = claimSetting.DocId,
                IsRequired = claimSetting.IsRequired,
                Claim = claimSetting.Claim,
                Company = claimSetting.Company,
                Doc = claimSetting.Doc
            };
            shipmentClaimsContext.ClaimSettings.Add(claimsetting);
            shipmentClaimsContext.SaveChanges();
            return Ok(claimsetting);
        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateClaimSetting(int id, ClaimSettingsUpdateDTO claimSetting)
        {
            if(id != claimSetting.SettingsId)
            {
                return BadRequest();
            }
            var claimsetting = shipmentClaimsContext.ClaimSettings.Find(id);
            if(claimsetting == null)
            {
                return BadRequest();
            }
            return Ok(claimsetting);
        }

        [HttpDelete("{id:int}")]

        public IActionResult DeleteClaimSetting(int id)
        {
            var claimSetting = shipmentClaimsContext.ClaimSettings.Find(id);
            if(claimSetting == null)
            {
                return BadRequest();
            }
            shipmentClaimsContext.ClaimSettings.Remove(claimSetting);
            shipmentClaimsContext.SaveChanges();
            return Ok();
        }
    }
}

