using ClaimsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.DTO.CompanyTypeDTO;
using System.Data;

namespace ClaimsAPI.Service.CompanyTypeService
{
    public class CompanyTypeService: ICompanyTypeService
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        private readonly RequestTokenInfo _requestTokenInfo;
        public CompanyTypeService(ShipmentClaimsContext shipmentClaimsContext, RequestTokenInfo requestTokenInfo)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
            this._requestTokenInfo = requestTokenInfo;
        }
        public async Task<IEnumerable<CompanyType>> GetCompanyTypes()
        {
            var companyTypes = await shipmentClaimsContext.CompanyTypes.ToListAsync();
            if (companyTypes == null)
            {
                return Enumerable.Empty<CompanyType>();
            }
            return companyTypes;
        }
        public async Task<CompanyType> GetCompanyTypeById(int id)
        {
            
            
            if(id.ToString() != _requestTokenInfo.userId)

            {
                throw new Exception("id is invalid");
            }

            var companyType = await shipmentClaimsContext.CompanyTypes.FirstOrDefaultAsync(ct => ct.CompanyTypeId == id);


            if (companyType == null)
            {
                throw new Exception($"company type with id : {id} not found");
            }
            return companyType;
        }
        public async Task<CompanyType> AddCompany(CompanyTypePostDTO company)
        {
            var CompanyType = new CompanyType()
            {
                CompanyType1 = company.CompanyType1
            };
            shipmentClaimsContext.CompanyTypes.Add(CompanyType);
            await shipmentClaimsContext.SaveChangesAsync();
            return CompanyType;
        }
        public async Task<CompanyType> UpdateCompany(int id, CompanyTypeUpdateDTO company)
        {
            if (id != company.CompanyTypeId)
            {
                throw new Exception($"comapnytype object and its id does not matches");
            }
            var CompanyType = shipmentClaimsContext.CompanyTypes.Find(id);
            if (CompanyType == null)
            {
                throw new Exception($"company type with id : {id} not found");
            }
            CompanyType.CompanyType1 = company.CompanyType1;
            shipmentClaimsContext.SaveChanges();
            return CompanyType;
        }
        public async Task<CompanyType> DeleteCompany(int id)
        {
            var companyType = shipmentClaimsContext.CompanyTypes.Find(id);
            if (companyType == null)
            {
                throw new Exception($"company type with id : {id} not found");
            }
            shipmentClaimsContext.CompanyTypes.Remove(companyType);
            shipmentClaimsContext.SaveChanges();
            return companyType;
        }
    }
}
