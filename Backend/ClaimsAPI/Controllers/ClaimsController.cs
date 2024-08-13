using ClaimsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClaimsAPI.Models.DTO.Claims;
using ClaimsAPI.Models.Entites;
using System.Threading;
using ClaimsAPI.Service.claim;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaim _claim;

        public ClaimsController(IClaim claim)
        {
            this._claim = claim;
        }

        [HttpGet]
        public async Task<IActionResult> GetClaims()
        {
            var claims =await _claim.GetClaims();
            if (claims == null)
            {
                return NotFound();
            }
            return Ok(claims);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetClaimTypeById(int id)
        {
            var claim =await _claim.GetClaimTypeById(id);
            if (claim == null)
            {
                return NotFound();
            }
            return Ok(claim);
        }

        [HttpPost]

        public async Task<IActionResult> AddClaim(ClaimPostDTO claim)
        {
            var Claim = await _claim.AddClaim(claim);
            return Ok(Claim);
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> UpdateClaims(int id, ClaimUpdateDTO claim)
        {
           var Claim = await _claim.UpdateClaims(id, claim);
            if (Claim == null)
            {
                return BadRequest();
            }
            return Ok(Claim);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteClaims(int id)
        {
            var claim = await _claim.DeleteClaims(id);
            if (claim == null)
            {
                return BadRequest();
            }
            return Ok(claim);
        }
    }
}