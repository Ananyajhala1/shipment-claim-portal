﻿using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClaimsAPI.Models.DTO.CompanyDTO;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;

        public CompanyController(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = shipmentClaimsContext.Companies.ToList();
            if (companies == null)
            {
                return NotFound();
            }
            return Ok(companies);
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetCompanyById(int id)
        {
            var company = shipmentClaimsContext.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]

        public IActionResult AddCompany(CompanyPostDTO company)
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
            shipmentClaimsContext.SaveChanges();
            return Ok(company);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult UpdateCompany(int id, CompanyUpdateDTO company)
        {
            if(id != company.CompanyId)
            {
                return BadRequest();
            }
            var Company = shipmentClaimsContext.Companies.Find(id);
            if (Company == null)
            {
                return BadRequest("Company does not exist");
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
            shipmentClaimsContext.SaveChanges();
            return Ok(Company);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteCompany(int id)
        {
            var company = shipmentClaimsContext.Companies.Find(id);
            if (company == null)
            {
                return BadRequest();
            }
            shipmentClaimsContext.Companies.Remove(company);
            shipmentClaimsContext.SaveChanges();
            return Ok(company);
        }
    }
}
