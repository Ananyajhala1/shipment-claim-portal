using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.ClaimEmailDTO;
using ClaimsAPI.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Service.claimEmail
{
    public class ClaimEmailService : IClaimEmail
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public ClaimEmailService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }

        public async Task<IEnumerable<ClaimEmail>> GetClaimEmails()
        {
            var claimEmails = await shipmentClaimsContext.ClaimEmails.ToListAsync();
            if (claimEmails == null)
            {
                return Enumerable.Empty<ClaimEmail>();
            }
            return claimEmails;
        }

        public async Task<ClaimEmail> GetClaimEmailsById(string id)
        {
            var claimEmail = await shipmentClaimsContext.ClaimEmails.FirstOrDefaultAsync(x => x.EmailId == id);
            if (claimEmail == null)
            {
                throw new Exception($"claim Email type with id : {id} not found");
            }
            return claimEmail;
        }

        public async Task<ClaimEmail> PostClaimEmail(ClaimEmailPostDTO claimEmail)
        {
            var newClaimEmail = new ClaimEmail()
            {
                Subject = claimEmail.Subject,
                Body = claimEmail.Body,
                RecepientId = claimEmail.RecepientId,
                ClaimId = claimEmail.ClaimId,
                FromId = claimEmail.FromId,
                DateSent = claimEmail.DateSent,
                From = claimEmail.From,
                Recepient = claimEmail.Recepient
            };

            shipmentClaimsContext.ClaimEmails.Add(newClaimEmail);
            await shipmentClaimsContext.SaveChangesAsync();
            return newClaimEmail;
        }

        public async Task<ClaimEmail> UpdateClaimEmail(string id, ClaimEmailUpdateDTO claimEmail)
        {
            var existingClaimEmail = await shipmentClaimsContext.ClaimEmails.FindAsync(id);
            if (existingClaimEmail == null)
            {
                return null;
            }

            existingClaimEmail.Subject = claimEmail.Subject;
            existingClaimEmail.Body = claimEmail.Body;

            await shipmentClaimsContext.SaveChangesAsync();
            return existingClaimEmail;
        }
        public async Task<ClaimEmail> DeleteClaimEmail(string id)
        {
            var claimEmail = await shipmentClaimsContext.ClaimEmails.FindAsync(id);
            if (claimEmail == null)
                return null;

            shipmentClaimsContext.ClaimEmails.Remove(claimEmail);
            await shipmentClaimsContext.SaveChangesAsync();
            return claimEmail;
        }
    }
}
