using ClaimsAPI.Models.Entities;

namespace ClaimsAPI.Models.ViewModels
{
    public class GetTemplateDTO
    {
        

        public string? TemplateName { get; set; }

        public string? TemplateType { get; set; }

        public string? TemplateContent { get; set; }

    }


    public class UpdateTemplateDTO
    {
        public int? UserId { get; set; }
        public string? TemplateName { get; set; }

        public string? TemplateType { get; set; }

        public string? TemplateContent { get; set; }





    }
}
