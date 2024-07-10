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

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var companies =await shipmentClaimsContext.Companies.ToListAsync();
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

        public async Task<Company> AddCompany(CompanyPostDTO company)
        {
            var Company = new Company()
            {
                CompanyTypeId = company.CompanyTypeId,
                CompanyName = company.CompanyName,
                IsCorporate = company.IsCorporate,
                ParentCompanyId = company.ParentCompanyId,
                ClaimCarriers = company.ClaimCarriers,
                ClaimCustomers = company.ClaimCustomers,
                ClaimDocumentTypes = company.ClaimDocumentTypes,
                ClaimEmails = company.ClaimEmails,
                ClaimInsurances = company.ClaimInsurances,
                ClaimSettings = company.ClaimSettings,
                ClaimSubStatuses = company.ClaimSubStatuses,
                Contacts = company.Contacts,
                InverseParentCompany = company.InverseParentCompany,
                Locations = company.Locations,
                ParentCompany = company.ParentCompany,
                UserInfos = company.UserInfos
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
            Company.ClaimCarriers = company.ClaimCarriers;
            Company.ClaimCustomers = company.ClaimCustomers;
            Company.ClaimDocumentTypes = company.ClaimDocumentTypes;
            Company.ClaimEmails = company.ClaimEmails;
            Company.ClaimInsurances = company.ClaimInsurances;
            Company.ClaimSettings = company.ClaimSettings;
            Company.ClaimSubStatuses = company.ClaimSubStatuses;
            Company.Contacts = company.Contacts;
            Company.InverseParentCompany = company.InverseParentCompany;
            Company.Locations = company.Locations;
            Company.ParentCompany = company.ParentCompany;
            Company.UserInfos = company.UserInfos;
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
