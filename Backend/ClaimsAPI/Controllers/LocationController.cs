using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.LocationDTO;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Service.location;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocation _location;

        public LocationController(ILocation location)
        {
            this._location = location;
        }
        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var Locations = await _location.GetLocations();
            if (Locations == null)
            {
                return NotFound();
            }
            return Ok(Locations);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetLocationById(int id)
        {
            var Location = await _location.GetLocationById(id);
            if (Location == null)
            {
                return NotFound();
            }
            return Ok(Location);
        }

        [HttpPost]

        public async Task<IActionResult> AddLocation(LocationPostDTO location)
        {
            var Location = await _location.AddLocation(location);
            return Ok(Location);
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> UpdateLocation(int id, LocationUpdateDTO location)
        {
            
            var Location = await _location.UpdateLocation(id, location);
            if (Location == null)
            {
                return BadRequest();
            }
            
            return Ok(Location);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteLocation(int id)
        {
            var Location = await _location.DeleteLocation(id);
            if (Location == null)
            {
                return BadRequest();
            }
            
            return Ok(Location);
        }
    }
}
