﻿using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models.DTO.LocationDTO
{
    public class LocationUpdateDTO
    {
        public int LocationId { get; set; }
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public int? Zipcode { get; set; }

        public int? CompanyId { get; set; }
    }
}
