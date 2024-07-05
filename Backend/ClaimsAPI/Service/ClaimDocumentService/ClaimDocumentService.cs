using ClaimsApi.Helpers;
using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Service.ClaimDocumentService
{
    public class ClaimDocumentService : IClaimDocumentService
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public ClaimDocumentService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }
        public async Task<IEnumerable<GetClaimDocumentDTO>> GetClaimDocuments(int cid)
        {
            var documents = await shipmentClaimsContext.ClaimDocuments.Where(p => p.ClaimId == cid).Select(p => new GetClaimDocumentDTO
            {
                ClaimId = p.ClaimId,
                DocTypeId = (int)p.DocTypeId,
                DocumentUrl = p.DocumentUrl,
                DoctypeDes = p.DocType.DoctypeDes
            }).ToListAsync();
            if(documents == null)
            {
                return Enumerable.Empty<GetClaimDocumentDTO>();
            }
            return documents;
        }
        public async Task<ClaimDocument> GetClaimdDocumentById(int id)
        {
            var doc = await shipmentClaimsContext.ClaimDocuments.FirstOrDefaultAsync(cd => cd.DocId == id);
            if(doc == null)
            {
                throw new Exception($"claim document with id {id} not found");
            }
            return doc;
        }
        public async Task<ClaimDocument> CreateClaimDocument(CreateClaimDocumnentDTO claimDocumnentDTO)
        {
            var base64URL = claimDocumnentDTO.DocumentBase64;
            byte[] bytes = Convert.FromBase64String(claimDocumnentDTO.DocumentBase64);

            var documentURL_temp = await FileHelper.UploadFiles(new MemoryStream(bytes), Guid.NewGuid().ToString());
            var newClaimDoc = new ClaimDocument
            {
                ClaimId = claimDocumnentDTO.ClaimId,
                DocTypeId = claimDocumnentDTO.DocTypeId,
                DocumentUrl = documentURL_temp
            };
            await shipmentClaimsContext.ClaimDocuments.AddAsync(newClaimDoc);
            await shipmentClaimsContext.SaveChangesAsync();
            return newClaimDoc;
        }

        public async Task<ClaimDocument> DeleteClaimDocument(int id)
        {
            var doc = await shipmentClaimsContext.ClaimDocuments.FirstOrDefaultAsync(cd => cd.DocId == id);
            if(doc == null)
            {
                throw new Exception($"doc with the id {id} does not exists");
            }
            shipmentClaimsContext.ClaimDocuments.Remove(doc);
            await shipmentClaimsContext.SaveChangesAsync();
            return doc;
        }
    }
}
