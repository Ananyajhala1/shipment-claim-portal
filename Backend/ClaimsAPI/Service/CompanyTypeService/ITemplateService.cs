using ClaimsAPI.Models.ViewModels;
using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Service.TemplatesService
{
    public interface ITemplateService
    {
        Task<GetTemplateDTO> GetTemplate(int id);
        Task<UserTemplate> CreateTempate(int uid, GetTemplateDTO templateDTO);
        Task<UserTemplate> UpdateTemplate(int id, UpdateTemplateDTO templateDTO);
        Task<UserTemplate> DeleteTemplate(int id);
        


    }
}
