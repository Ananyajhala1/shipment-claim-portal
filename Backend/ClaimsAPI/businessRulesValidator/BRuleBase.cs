using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.DTO.CompanyTypeDTO;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;







namespace ClaimsAPI.businessRulesValidator
{
    public abstract class BRuleBase
    {

        public string error { get; set; }

        private readonly ShipmentClaimsContext _shipmentClaimsContext;


        public BRuleBase(ShipmentClaimsContext shipmentClaimsContext)
        {
            _shipmentClaimsContext = shipmentClaimsContext;

        }

        public abstract bool Execute();


    }


    }
