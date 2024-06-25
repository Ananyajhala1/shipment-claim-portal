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
    public class ClaimDocumentsController : ControllerBase
    {

        private readonly ShipmentClaimsContext _dbContext;
        public ClaimDocumentsController(ShipmentClaimsContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(GetClaimDocumentDTO claimDocumentDTO)


 
        {
            var base64URL = claimDocumentDTO.DocumentBase64;


            byte[] byets = Convert.FromBase64String(claimDocumentDTO.DocumentBase64);



            var DocumentUrl1 = await FileHelper.UploadFiles(new MemoryStream(byets), Guid.NewGuid().ToString());

            //   var imageUrl = await FileHelper.UploadImage(song.Image);
           
            var template = new ClaimDocument
            {
               ClaimId = claimDocumentDTO.ClaimId,
               DocTypeId = claimDocumentDTO.DocTypeId,
                DocumentUrl = DocumentUrl1

               
            
            };
            await _dbContext.ClaimDocuments.AddAsync(template);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }



        [HttpGet]
        public async Task<IActionResult> GetClaimDocument(int id)
        {
            var template = await _dbContext.ClaimDocuments
                .Where(p => p.DocId == id)
                .Select(p => new GetClaimDocumentDTO
                {
                    ClaimId = p.ClaimId,
                    DocTypeId = p.DocTypeId,
                    DocumentBase64 = 
                
                }).FirstOrDefaultAsync();

            if (template == null)
            {
                return NotFound();
            }

            return Ok(template);
        }







    }
}
