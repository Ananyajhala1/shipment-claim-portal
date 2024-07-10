using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.ClaimSettingsDTO;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Service.claimSettings;
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
        private readonly IClaimSettings _ClaimSettings;

        public ClaimSettingsController(IClaimSettings claimSettings)
        {
            this._ClaimSettings = claimSettings;
        }

        [HttpGet]
        public async Task<IActionResult> GetClaimSettings()
        {
            var claimSettings = await _ClaimSettings.GetClaimSettings();
            if(claimSettings == null)
            {
                return BadRequest();
            }
            return Ok(claimSettings);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetClaimSettingById(int id)
        {
            var claimSetting = await _ClaimSettings.GetClaimSettingById(id);
            if(claimSetting == null)
            {
                return BadRequest();
            }
            return Ok(claimSetting);
        }

        [HttpPost]

        public async Task<IActionResult> PostClaimSetting(ClaimSettingsPostDTO claimSetting)
        {
           var claimsetting = await _ClaimSettings.PostClaimSetting(claimSetting);
           return Ok(claimsetting);
        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateClaimSetting(int id, ClaimSettingsUpdateDTO claimSetting)
        {
            var claimsetting =await _ClaimSettings.UpdateClaimSetting(id, claimSetting);
            if(claimsetting == null)
            {
                return BadRequest();
            }
            return Ok(claimsetting);
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteClaimSetting(int id)
        {
            var claimSetting = await _ClaimSettings.DeleteClaimSetting(id);
            return Ok(claimSetting);
        }
    }
}

