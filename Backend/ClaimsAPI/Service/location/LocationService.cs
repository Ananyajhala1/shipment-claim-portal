using ClaimsAPI.Models;
using ClaimsAPI.Models.DTO.LocationDTO;
using ClaimsAPI.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Service.location
{
    public class LocationService: ILocation
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public LocationService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            var Locations =await shipmentClaimsContext.Locations.ToListAsync();
            if (Locations == null)
            {
                return Enumerable.Empty<Location>();
            }
            return Locations;
        }
        public async Task<Location> GetLocationById(int id)
        {
            var Location =await shipmentClaimsContext.Locations.FirstOrDefaultAsync(x => x.LocationId == id);
            if (Location == null)
            {
                return null;
            }
            return Location;
        }
        public async Task<Location> AddLocation(LocationPostDTO location)
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
            await shipmentClaimsContext.SaveChangesAsync();
            return Location;
        }
        public async Task<Location> UpdateLocation(int id, LocationUpdateDTO location)
        {
            if (id != location.LocationId)
            {
                throw new Exception("id didn't match");
            }
            var Location = await shipmentClaimsContext.Locations.FirstOrDefaultAsync(x => x.LocationId == id);
            if (Location == null)
            {
                return null;
            }
            Location.Name = location.Name;
            Location.Address = location.Address;
            Location.City = location.City;
            Location.State = location.State;
            Location.Country = location.Country;
            Location.Zipcode = location.Zipcode;
            Location.CompanyId = location.CompanyId;
            Location.Company = location.Company;
            await shipmentClaimsContext.SaveChangesAsync();
            return Location;
        }
        public async Task<Location> DeleteLocation(int id)
        {
            var Location = await shipmentClaimsContext.Locations.FirstOrDefaultAsync(x => x.LocationId == id);
            if (Location == null)
            {
                return null;
            }
            shipmentClaimsContext.Locations.Remove(Location);
            await shipmentClaimsContext.SaveChangesAsync();
            return Location;
        }
    }
}
