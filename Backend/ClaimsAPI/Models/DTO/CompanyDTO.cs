using ClaimsAPI.Models.Entities;

namespace ClaimsAPI.Models.DTO
{
    public class CompanyDTO
    {
        public int? CompanyTypeId { get; set; }

        public string CompanyName { get; set; } = null!;

        public bool IsCorporate { get; set; }

        public Guid? ParentCompanyId { get; set; }

        public virtual ICollection<Claim> ClaimCarriers { get; set; } = new List<Claim>();

        public virtual ICollection<Claim> ClaimCustomers { get; set; } = new List<Claim>();

        public virtual ICollection<ClaimDocumentType> ClaimDocumentTypes { get; set; } = new List<ClaimDocumentType>();

        public virtual ICollection<ClaimEmail> ClaimEmails { get; set; } = new List<ClaimEmail>();

        public virtual ICollection<Claim> ClaimInsurances { get; set; } = new List<Claim>();

        public virtual ICollection<ClaimSetting> ClaimSettings { get; set; } = new List<ClaimSetting>();

        public virtual ICollection<ClaimSubStatus> ClaimSubStatuses { get; set; } = new List<ClaimSubStatus>();

        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

        public virtual ICollection<Company> InverseParentCompany { get; set; } = new List<Company>();

        public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

        public virtual Company? ParentCompany { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; } = new List<UserInfo>();
    }
}
