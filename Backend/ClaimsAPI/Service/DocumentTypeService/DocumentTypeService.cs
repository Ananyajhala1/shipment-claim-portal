using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.DocumentType;
using ClaimsAPI.Models.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace ClaimsAPI.Service.DocumentTypeService
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public DocumentTypeService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }
        public async Task<IEnumerable<ClaimDocumentType>> GetDocumentTypes()
        {
            var documentTypes = shipmentClaimsContext.ClaimDocumentTypes.ToList();
            if (documentTypes == null)
            {
                return Enumerable.Empty<ClaimDocumentType>();
            }
            return documentTypes;
        }
        public async Task<ClaimDocumentType> GetDocumentTypeByID(int id)
        {
            var documentType = shipmentClaimsContext.ClaimDocumentTypes.FirstOrDefaultAsync(dt => dt.DocTypeId == id);
            if (documentType == null)
            {
                throw new Exception($"claim document type with id {id} doesnot exits");
            }
            return await documentType;
        }
        public async Task<ClaimDocumentType> AddDocType(DocumentTypePostDTO cdt)
        {
            var documentType = new ClaimDocumentType
            {
                DoctypeDes = cdt.DoctypeDes,
                ClaimDocuments = cdt.ClaimDocuments,
                Company = cdt.Company,
                CompanyId = (int)cdt.CompanyId
            };
            await shipmentClaimsContext.ClaimDocumentTypes.AddAsync(documentType);
            await shipmentClaimsContext.SaveChangesAsync();
            return documentType;
        }

        public async Task<ClaimDocumentType> UpdateDocType(int id, DocumentTypeUpdateDTO cdt)
        {
            if(id != cdt.DocTypeId)
            {
                throw new Exception($"document type object and its id does not matches");
            }
            var docType = await shipmentClaimsContext.ClaimDocumentTypes.FirstOrDefaultAsync(dt => dt.DocTypeId == id);
            if(docType == null)
            {
                throw new Exception($"document type with id : {id} not found");
            }
            docType.DoctypeDes = cdt.DoctypeDes;
            docType.ClaimDocuments = cdt.ClaimDocuments;
            docType.Company = cdt.Company;
            docType.CompanyId = (int)cdt.CompanyId;
            await shipmentClaimsContext.SaveChangesAsync();
            return docType;
        }

        public async Task<ClaimDocumentType> DeleteDocType(int id)
        {
            var deleteDocType = await shipmentClaimsContext.ClaimDocumentTypes.FirstOrDefaultAsync(dt => dt.DocTypeId == id);
            if (deleteDocType == null)
            {
                throw new Exception($"document type with id : {id} not found");
            }
            shipmentClaimsContext.ClaimDocumentTypes.Remove(deleteDocType);
            await shipmentClaimsContext.SaveChangesAsync();
            return deleteDocType;
        }
    }
}