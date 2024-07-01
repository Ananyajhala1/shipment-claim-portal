using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models.ViewModels
{
   


    public class GetClaimDocumentTypeDTO
    {



        public string? DoctypeDes { get; set; }

        public int CompanyId { get; set; }


    }

    public class UpdateClaimDocumentTypeDTO
    {


        public int DocTypeId { get; set; }
        public string? DoctypeDes { get; set; }

        public int CompanyId { get; set; }




    }


}
