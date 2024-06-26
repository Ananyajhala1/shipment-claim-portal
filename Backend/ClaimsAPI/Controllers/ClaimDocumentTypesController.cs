using ClaimsApi.Helpers;
using ClaimsAPI.Models;
using ClaimsAPI.Models.Entities;
using ClaimsAPI.Models.ViewModels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimDocumentTypesController : ControllerBase
    {

        private readonly ShipmentClaimsContext _dbContext;
        public ClaimDocumentTypesController(ShipmentClaimsContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetClaimDocumentType(int id)
        {
            var document = await _dbContext.ClaimDocumentTypes
                .Where(p => p.DocTypeId == id)
                .Select(p => new GetClaimDocumentTypeDTO
                {
                  DoctypeDes = p.DoctypeDes,
                  CompanyId = p.CompanyId

                 
                }).FirstOrDefaultAsync();

            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClaimDocumentType(GetClaimDocumentTypeDTO claimDocumentTypeDTO)
        {
            if (claimDocumentTypeDTO == null)
            {
                return BadRequest("document is null.");
            }


            var document = new ClaimDocumentType
            {
                DoctypeDes = claimDocumentTypeDTO.DoctypeDes,
                CompanyId = claimDocumentTypeDTO.CompanyId
            
            };

            _dbContext.ClaimDocumentTypes.Add(document);
            await _dbContext.SaveChangesAsync();

            return Ok(document);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClaimDocumentType( UpdateClaimDocumentTypeDTO claimDocumentTypeDTO)
        {
            var documentToUpdate = await _dbContext.ClaimDocumentTypes.FindAsync(claimDocumentTypeDTO.DocTypeId);
            if (documentToUpdate == null)
            {
                return NotFound("template not found.");
            }
            documentToUpdate.DoctypeDes = claimDocumentTypeDTO.DoctypeDes;
            documentToUpdate.CompanyId = claimDocumentTypeDTO.CompanyId;


            _dbContext.ClaimDocumentTypes.Update(documentToUpdate);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteClaimDocumentType(int id)
        {
            var  document = await _dbContext.ClaimDocumentTypes.FindAsync(id);
            if (document == null)
            {
                return NotFound("document not found.");
            }

            _dbContext.ClaimDocumentTypes.Remove(document);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }











    }
}
