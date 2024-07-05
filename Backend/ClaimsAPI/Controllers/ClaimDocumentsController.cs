using ClaimsApi.Helpers;
using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using ClaimsAPI.Service.ClaimDocumentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimDocumentsController : ControllerBase
    {

        private readonly IClaimDocumentService _claimDocumentService;
        public ClaimDocumentsController(IClaimDocumentService claimDocumentService)
        {
           _claimDocumentService = claimDocumentService; 
        }
        [HttpGet]
        public async Task<ActionResult<GetClaimDocumentDTO>> GetClaimDocument(int cid)
        {
            var claimDocuments = await _claimDocumentService.GetClaimDocuments(cid);
            if (claimDocuments == null)
            {
                return NotFound();
            }
            return Ok(claimDocuments);
        }
        [HttpGet("[action]/id:int")]
        public async Task<ActionResult<ClaimDocument>> GetClaimDocumentbyId(int id)
        {
            var doc = await _claimDocumentService.GetClaimdDocumentById(id);
            if (doc == null)
            {
                return NotFound();
            }
            return Ok(doc);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<ClaimDocument>> createClaimDoc(CreateClaimDocumnentDTO claimDoc)
        {
            var doc = await _claimDocumentService.CreateClaimDocument(claimDoc);
            if (doc == null)
            {
                return NotFound();
            }
            return Ok(doc);
        }
        [HttpDelete("[action]")]
        public async Task<ActionResult<ClaimDocument>> deleteClaimDocument(int id)
        {
            var doc = await _claimDocumentService.DeleteClaimDocument(id);
            if(doc == null)
            {
                return NotFound();
            }
            return Ok(doc);
        }

    }
}
