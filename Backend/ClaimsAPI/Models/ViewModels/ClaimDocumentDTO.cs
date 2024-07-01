using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models.ViewModels
{
    public class CreateClaimDocumnentDTO {
       

        public int? ClaimId { get; set; }

        public int DocTypeId { get; set; }



        public string DocumentBase64 { get; set; }


    }


    public class GetClaimDocumentDTO
    {

        public string DocumentUrl { get; set; }
        public int? ClaimId { get; set; }
        public string? DoctypeDes { get; set; }
        public int DocTypeId { get; set; }

    }
    public class GetClaimDocumentDTOById
    {
        public string  Base64string { get; set; }
    
        public int? ClaimId { get; set; }

        public int DocTypeId { get; set; }




    }

}
