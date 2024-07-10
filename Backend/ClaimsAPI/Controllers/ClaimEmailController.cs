using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.ClaimEmailDTO;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Service.claimEmail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimEmailController : ControllerBase
    {
        private readonly IClaimEmail _claimEmail;
        public ClaimEmailController(IClaimEmail claimEmail)
        {
            this._claimEmail = claimEmail;
        }

        [HttpGet]
        public async Task<IActionResult> GetClaimEmails()
        {
            var claimEmails = await _claimEmail.GetClaimEmails();
            return Ok(claimEmails);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetClaimEmailsById(string id)
        {
            var claimEmail = await _claimEmail.GetClaimEmailsById(id);
            if (claimEmail == null)
            {
                return NotFound();
            }
            return Ok(claimEmail);
        }

        [HttpPost]
        public async Task<IActionResult> PostClaimEmail(ClaimEmailPostDTO claimEmail)
        {
            var addedClaimEmail = await _claimEmail.PostClaimEmail(claimEmail);
            return Ok(addedClaimEmail);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateClaimEmail(string id, ClaimEmailUpdateDTO claimEmail)
        {
            var updatedClaimEmail = await _claimEmail.UpdateClaimEmail(id, claimEmail);
            if (updatedClaimEmail == null)
            {
                return NotFound();
            }
            return Ok(updatedClaimEmail);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteClaimEmail(string id)
        {
            var result = await _claimEmail.DeleteClaimEmail(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}