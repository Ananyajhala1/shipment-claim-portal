using ClaimsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClaimsAPI.Models.DTO.DocumentType;
using ClaimsAPI.Models.Entites;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public DocumentTypeController(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaimDocumentType>>> GetDocumentTypes()
        {
            var docTypes = await shipmentClaimsContext.ClaimDocumentTypes.ToListAsync();
            if(docTypes == null)
            {
                return NotFound();
            }
            return Ok(docTypes);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ClaimDocumentType>> GetDocumentTypeByID(int id)
        {
            var doctype = await shipmentClaimsContext.ClaimDocumentTypes.FirstOrDefaultAsync(dt => dt.DocTypeId == id);
            if (doctype == null)
            {
                return NotFound();
            }
            return Ok(doctype);
        }
        [HttpPost]
        public async Task<ActionResult<ClaimDocumentType>> AddDocType(DocumentTypePostDTO cdt)
        {
            var NewClaimDocumentType = new ClaimDocumentType();
            NewClaimDocumentType.DoctypeDes = cdt.DoctypeDes;
            NewClaimDocumentType.ClaimDocuments = cdt.ClaimDocuments;
            NewClaimDocumentType.Company = cdt.Company;
            NewClaimDocumentType.CompanyId = (int)cdt.CompanyId;
            shipmentClaimsContext.ClaimDocumentTypes.Add(NewClaimDocumentType);
            await shipmentClaimsContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ClaimDocumentType>> UpdateDocType(int id , DocumentTypeUpdateDTO cdt)
        {
            if(id != cdt.DocTypeId)
            {
                return BadRequest();
            }
            var UpdatedClaimDocumentType = await shipmentClaimsContext.ClaimDocumentTypes.FirstOrDefaultAsync(dt => dt.DocTypeId == id);
            if (UpdatedClaimDocumentType == null)
            {
                return BadRequest();
            }
            UpdatedClaimDocumentType.DocTypeId = cdt.DocTypeId;
            UpdatedClaimDocumentType.DoctypeDes = cdt.DoctypeDes;
            UpdatedClaimDocumentType.ClaimDocuments = cdt.ClaimDocuments;
            UpdatedClaimDocumentType.Company = cdt.Company;
            UpdatedClaimDocumentType.CompanyId = (int)cdt.CompanyId;
            return Ok(UpdatedClaimDocumentType);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<ClaimDocumentType>> DeleteDocType(int id)
        {
            var deleteDocType = await shipmentClaimsContext.ClaimDocumentTypes.FirstOrDefaultAsync(dt => dt.DocTypeId == id);
            if (deleteDocType == null)
            {
                return NotFound();
            }
            shipmentClaimsContext.ClaimDocumentTypes.Remove(deleteDocType);
            await shipmentClaimsContext.SaveChangesAsync();
            return Ok(deleteDocType);
        }

    }
}
