using ClaimsAPI.Models.DTO.CompanyTypeDTO;
using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Service.CompanyTypeService
{
    public interface ICompanyTypeService
    {
        IEnumerable<CompanyType> GetCompanyTypes();
        CompanyType GetCompanyTypeById(int id);
        CompanyType AddCompany(CompanyTypePostDTO company);
        CompanyType UpdateCompany(int id, CompanyTypeUpdateDTO company);
        CompanyType DeleteCompany(int id);


    }
}
