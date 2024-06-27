using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.ClaimEmailDTO;
using ClaimsAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimEmailController : ControllerBase
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;

        public ClaimEmailController(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }

        [HttpGet]
        public IActionResult GetClaimEmails()
        {
            var claimEmails = shipmentClaimsContext.ClaimEmails.ToList();
            if(claimEmails == null)
            {
                return BadRequest();
            }
            return Ok(claimEmails);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetClaimEmailsById(string id)
        {
            var claimEmails = shipmentClaimsContext.ClaimEmails.Find(id);
            if (claimEmails == null)
            {
                return BadRequest();
            }
            return Ok(claimEmails);
        }

        [HttpPost]
        public IActionResult PostClaimEmail(ClaimEmailPostDTO claimEmail)
        {
            var claimemail = new ClaimEmail()
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
            shipmentClaimsContext.ClaimEmails.Add(claimemail);
            shipmentClaimsContext.SaveChanges();
            return Ok(claimEmail);
        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult UpdateClaimEmail(string id, ClaimEmailUpdateDTO claimEmail)
        {
            if(id!= claimEmail.EmailId)
            {
                return BadRequest();
            }
            var claimemail = shipmentClaimsContext.ClaimEmails.Find(id);
            if(claimemail == null)
            {
                return BadRequest();
            }
            claimemail.Subject = claimEmail.Subject;
            claimemail.Body = claimEmail.Body;
            shipmentClaimsContext.SaveChanges();
            return Ok(claimemail);
        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult DeleteClaimEmail(string id)
        {
            var claimEmail = shipmentClaimsContext.ClaimEmails.Find(id);
            if(claimEmail == null)
            {
                return BadRequest();
            }
            shipmentClaimsContext.ClaimEmails.Remove(claimEmail);
            shipmentClaimsContext.SaveChanges();
            return Ok();
        }
    }
}