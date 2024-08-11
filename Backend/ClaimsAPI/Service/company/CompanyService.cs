using ClaimsAPI.businessRulesValidator;
using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.CompanyDTO;
using ClaimsAPI.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Service.company
{
    public class CompanyService: ICompany
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        private readonly RequestTokenInfo _requestToken;

        public CompanyService(ShipmentClaimsContext shipmentClaimsContext, RequestTokenInfo requestToken)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
            this._requestToken = requestToken;
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



        public async Task<IEnumerable<Company>> GetCarrier(int companyid)
        {


            var clientValidatorRule = new ClientValidatorBRule(shipmentClaimsContext, companyid, _requestToken);


            var rules = new List<BRuleBase>();
            rules.Add(clientValidatorRule);

            var bRuleRunner = new BRuleRunner(rules);

            bRuleRunner.ExecuteRules();


            if (!bRuleRunner.hasError())
            { 

            var carriers = await shipmentClaimsContext.Companies.Where(x => (x.CompanyTypeId == 2) && x.ParentCompanyId == companyid).ToListAsync();
                if (carriers == null)
                {
                return Enumerable.Empty<Company>();
                }
               return carriers;
            }

            else
            {
                //todo: return error 
                  return Enumerable.Empty<Company>(); ;

            }


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
