using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.LocationDTO;
using ClaimsAPI.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;

        public LocationController(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }
        [HttpGet]
        public IActionResult GetLocations()
        {
            var Locations = shipmentClaimsContext.Locations.ToList();
            if (Locations == null)
            {
                return NotFound();
            }
            return Ok(Locations);
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetLocationById(int id)
        {
            var Location = shipmentClaimsContext.Locations.Find(id);
            if (Location == null)
            {
                return NotFound();
            }
            return Ok(Location);
        }

        [HttpPost]

        public IActionResult AddLocation(LocationPostDTO location)
        {
            var Location = new Location()
            {
                Name = location.Name,
                Address = location.Address,
                City = location.City,
                State = location.State,
                Country = location.Country,
                Zipcode = location.Zipcode,
                CompanyId = location.CompanyId,
                Company = location.Company
            };
            shipmentClaimsContext.Locations.Add(Location);
            shipmentClaimsContext.SaveChanges();
            return Ok(Location);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult UpdateCompany(int id, LocationUpdateDTO location)
        {
            if (id != location.LocationId)
            {
                return BadRequest();
            }
            var Location = shipmentClaimsContext.Locations.Find(id);
            if (Location == null)
            {
                return BadRequest();
            }
            Location.Name = location.Name;
            Location.Address = location.Address;
            Location.City = location.City;
            Location.State = location.State;
            Location.Country = location.Country;
            Location.Zipcode = location.Zipcode;
            Location.CompanyId = location.CompanyId;
            Location.Company = location.Company;
            shipmentClaimsContext.SaveChanges();
            return Ok(Location);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteCompany(int id)
        {
            var Location = shipmentClaimsContext.Locations.Find(id);
            if (Location == null)
            {
                return BadRequest();
            }
            shipmentClaimsContext.Locations.Remove(Location);
            shipmentClaimsContext.SaveChanges();
            return Ok(Location);
        }
    }
}
