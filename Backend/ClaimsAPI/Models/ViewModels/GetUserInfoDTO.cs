﻿using ClaimsAPI.Models.Entities;

namespace ClaimsAPI.Models.ViewModels
{
    public class GetUserInfoDTO
    {


        public int? UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? ContactNumber { get; set; } 

        public string? email { get; set; }
        public int CompanyId { get; set; }



    }
}
