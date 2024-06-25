using ClaimsAPI.Models.Entities;

namespace ClaimsAPI.Models.ViewModels
{
    public class GetClaimDocumentDTO
    {
       

        public int? ClaimId { get; set; }

        public int DocTypeId { get; set; }



        public string DocumentBase64 { get; set; }


    }


}
