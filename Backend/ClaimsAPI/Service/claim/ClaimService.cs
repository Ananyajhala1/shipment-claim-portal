using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.Claims;
using ClaimsAPI.Models.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Service.claim
{
    public class ClaimService: IClaim
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public ClaimService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }

        public async Task<IEnumerable<Claim>> GetClaims()
        {
            var claims = await shipmentClaimsContext.Claims.ToListAsync();
            if (claims == null)
            {
                return Enumerable.Empty<Claim>();
            }
            return claims;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<Claim> GetClaimTypeById(int id)
        {
            var claim = await shipmentClaimsContext.Claims.FirstOrDefaultAsync(x => x.ClaimId == id);
            if (claim == null)
            {
                return null;
            }
            return claim;
        }

        [HttpPost]

        public async Task<Claim> AddClaim(ClaimPostDTO claim)
        {
            var Claim = new Claim()
            {
                FileDate = claim.FileDate,
                CustomerId = claim.CustomerId,
                CarrierId = claim.CarrierId,
                InsuranceId = claim.InsuranceId,
                Carrier = claim.Carrier,
                ClaimDocuments = claim.ClaimDocuments,
                ClaimSettings = claim.ClaimSettings,
                ClaimStatuses = claim.ClaimStatuses,
                ClaimTasks = claim.ClaimTasks,
                Customer = claim.Customer,
                Insurance = claim.Insurance
            };
            shipmentClaimsContext.Claims.Add(Claim);
            await shipmentClaimsContext.SaveChangesAsync();
            return Claim;
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<Claim> UpdateClaims(int id, ClaimUpdateDTO claim)
        {
            if (id != claim.ClaimId)
            {
                throw new Exception("id didn't match") ;
            }
            var Claim = await shipmentClaimsContext.Claims.FirstOrDefaultAsync(x => x.ClaimId == id);
            if (Claim == null)
            {
                return null;
            }

            Claim.ClaimDocuments = claim.ClaimDocuments;
            Claim.ClaimSettings = claim.ClaimSettings;
            Claim.ClaimStatuses = claim.ClaimStatuses;
            Claim.ClaimTasks = claim.ClaimTasks;
            await shipmentClaimsContext.SaveChangesAsync();
            return Claim;
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<Claim> DeleteClaims(int id)
        {
            var claim = await shipmentClaimsContext.Claims.FirstOrDefaultAsync(x => x.ClaimId == id);
            if (claim == null)
            {
                return null;
            }
            shipmentClaimsContext.Claims.Remove(claim);
            await shipmentClaimsContext.SaveChangesAsync();
            return claim;
        }
    }
}
