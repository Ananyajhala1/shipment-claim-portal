using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.CompanyDTO;
using ClaimsAPI.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Service.company
{
    public class CompanyService: ICompany
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public CompanyService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }

        public async Task<IEnumerable<Company>> GetCompanies(int clientID)
        {
            // will return all the companies that has parentcompanyID equal to clientId
            var companies =await shipmentClaimsContext.Companies.Where(c => c.ParentCompanyId == clientID || c.CompanyId == 1).ToListAsync();
            if (companies == null)
            {
                return Enumerable.Empty<Company>();
            }
            return companies;
        }

        public async Task<Company> GetCompanyById(int id)
        {
            var company = await shipmentClaimsContext.Companies.FirstOrDefaultAsync(x => x.CompanyId == id);
            if (company == null)
            {
                return null;
            }
            return company;
        }

        public async Task<Company> AddCompany(CompanyPostDTO company, int clientId)
        {
            var Company = new Company()
            {
                CompanyTypeId = company.CompanyTypeId,
                CompanyName = company.CompanyName,
                IsCorporate = company.IsCorporate,
                ParentCompanyId = clientId,
            };
            shipmentClaimsContext.Companies.Add(Company);
            await shipmentClaimsContext.SaveChangesAsync();
            return Company;
        }

        public async Task<Company> UpdateCompany(int id, CompanyUpdateDTO company)
        {
            if (id != company.CompanyId)
            {
                throw new Exception("id didn't match");
            }
            var Company = await shipmentClaimsContext.Companies.FirstOrDefaultAsync(x => x.CompanyId == id);
            if (Company == null)
            {
                return null;
            }
            Company.CompanyTypeId = company.CompanyTypeId;
            Company.CompanyName = company.CompanyName;
            Company.IsCorporate = company.IsCorporate;
            Company.ParentCompanyId = company.ParentCompanyId;
            await shipmentClaimsContext.SaveChangesAsync();
            return Company;
        }
        public async Task<Company> DeleteCompany(int id)
        {
            var company = await shipmentClaimsContext.Companies.FirstOrDefaultAsync(x => x.CompanyId == id);
            if (company == null)
            {
                return null;
            }
            shipmentClaimsContext.Companies.Remove(company);
            await shipmentClaimsContext.SaveChangesAsync();
            return company;
        }

    }
}
