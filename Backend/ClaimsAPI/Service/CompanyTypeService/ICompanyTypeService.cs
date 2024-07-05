using ClaimsAPI.Models.DTO.CompanyTypeDTO;
using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Service.CompanyTypeService
{
    public interface ICompanyTypeService
    {
        Task<IEnumerable<CompanyType>> GetCompanyTypes();
        Task<CompanyType> GetCompanyTypeById(int id);
        Task<CompanyType> AddCompany(CompanyTypePostDTO company);
        Task<CompanyType> UpdateCompany(int id, CompanyTypeUpdateDTO company);
        Task<CompanyType> DeleteCompany(int id);


    }
}
