namespace ClaimsAPI.Models.DTO.LocationDTO;
using ClaimsAPI.Models.Entites;

public class LocationPostDTO
{ 
    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public int? Zipcode { get; set; }

    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }
}
