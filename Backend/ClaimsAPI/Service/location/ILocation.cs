using ClaimsAPI.Models.DTO.LocationDTO;
using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Service.location
{
    public interface ILocation
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<Location> GetLocationById(int id);
        Task<Location> AddLocation(LocationPostDTO location);
        Task<Location> UpdateLocation(int id, LocationUpdateDTO location);
        Task<Location> DeleteLocation(int id);
    }
}
