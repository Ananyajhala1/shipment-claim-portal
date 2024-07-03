using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.DTO.CompanyDTO;

namespace ClaimsAPI.Service.company
{
    public interface ICompany
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompanyById(int id);

        Task<Company> AddCompany(CompanyPostDTO company);
        Task<Company> UpdateCompany(int id, CompanyUpdateDTO company);
        Task<Company> DeleteCompany(int id);
    }
}
