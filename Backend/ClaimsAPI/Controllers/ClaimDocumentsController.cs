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
        public async Task<IActionResult> Post(CreateClaimDocumnentDTO claimDocumentDTO)


 
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
        public async Task<IActionResult> GetClaimDocument(int cid)
        {
            var document = await _dbContext.ClaimDocuments
                .Where(p => p.ClaimId== cid)
                .Select(p => new GetClaimDocumentDTO
                {
                    ClaimId = p.ClaimId,
                    DocTypeId = p.DocTypeId,
                    DocumentUrl = p.DocumentUrl,
                    DoctypeDes = p.DocType.DoctypeDes



                }).FirstOrDefaultAsync();

            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteClaimDocument(int id)
        {
            var document = await _dbContext.ClaimDocuments.FindAsync(id);
            if (document == null)
            {
                return NotFound("document not found.");
            }

            _dbContext.ClaimDocuments.Remove(document);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }



        [HttpGet("getclaimdocumentbyId")]
        public async Task<IActionResult> GetClaimDocumentbyId(int id)
        {
            var document = await _dbContext.ClaimDocuments
                .Where(p => p.ClaimId == id)
                .Select(p => new GetClaimDocumentDTO
                {
                    ClaimId = p.ClaimId,
                    DocTypeId = p.DocTypeId,
                    DocumentUrl = p.DocumentUrl,
                    DoctypeDes = p.DocType.DoctypeDes

                   


                }).FirstOrDefaultAsync();

            if (document == null)
            {
                return NotFound();
            }

            var base64Url = await FileHelper.DownloadFiles(document.DocumentUrl);

            GetClaimDocumentDTOById document2 = new GetClaimDocumentDTOById();

            document2.DocTypeId = document.DocTypeId; 
            document2.ClaimId = document.ClaimId;
            document2.Base64string = base64Url;





            return Ok(document2);
        }






    }
}
