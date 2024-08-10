using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.DTO.CompanyDTO;

namespace ClaimsAPI.Service.company
{
    public interface ICompany
    {
        Task<IEnumerable<Company>> GetCompanies(int clientID);
        Task<Company> GetCompanyById(int id);

        Task<Company> AddCompany(CompanyPostDTO company, int clientId);
        Task<Company> UpdateCompany(int id, CompanyUpdateDTO company);
        Task<Company> DeleteCompany(int id);
    }
}
