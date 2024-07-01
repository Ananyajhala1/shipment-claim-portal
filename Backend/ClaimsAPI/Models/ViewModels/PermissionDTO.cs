namespace ClaimsAPI.Models.ViewModels
{
    public class GetPermissionsDTO
    {
        public int PermissionId { get; set; }
        public string? PermissionDescription { get; set; }
        public bool? AllowClient { get; set; }
        public bool? AllowCarrier { get; set; }
        public bool? AllowInsurance { get; set; }
    }

    public class CreateUpdatePermissionDTO
    {
        public string? PermissionDescription { get; set; }
        public bool? AllowClient { get; set; }
        public bool? AllowCarrier { get; set; }
        public bool? AllowInsurance { get; set; }
    }
}