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
using ClaimsAPI.Service.DocumentTypeService;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeService _documentTypeService;
        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaimDocumentType>>> GetDocumentTypes()
        {
            var docTypes = await _documentTypeService.GetDocumentTypes();
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
            var docType = await _documentTypeService.GetDocumentTypeByID(id);
            if(docType == null)
            {
                return NotFound();
            }
            return Ok(docType);
        }
        [HttpPost]
        public async Task<ActionResult<ClaimDocumentType>> AddDocType(DocumentTypePostDTO cdt)
        {
            var docType = await _documentTypeService.AddDocType(cdt);
            return Ok(docType);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ClaimDocumentType>> UpdateDocType(int id, DocumentTypeUpdateDTO cdt)
        {
            var docType = await _documentTypeService.UpdateDocType(id, cdt);
            if(docType.DocTypeId != id)
            {
                return BadRequest();
            }
            if(docType == null)
            {
                return NotFound();
            }
            return Ok(docType);
        }
        [HttpDelete]
        public async Task<ActionResult<ClaimDocumentType>> DeleteDocType(int id)
        {
            var docType = await _documentTypeService.DeleteDocType(id);
            if(docType == null)
            {
                return NotFound();
            }
            return Ok(docType);
        }



    }
}
