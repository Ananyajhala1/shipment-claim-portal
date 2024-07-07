using ClaimsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using System.Data;

namespace ClaimsAPI.Service.TemplatesService
{
    public class TemplatesService : ITemplateService
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public TemplatesService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }
        public async Task<GetTemplateDTO> GetTemplate(int id)
        {

            var template = await shipmentClaimsContext.UserTemplates
                .Where(p => p.UserId == id)
                .Select(p => new GetTemplateDTO
                {
                    TemplateName = p.TemplateName,
                    TemplateType = p.TemplateType,
                    TemplateContent = p.TemplateContent
                }).FirstOrDefaultAsync();

            if (template == null)
            {
                throw new Exception($" template with id : {id} not found");
            }

            return template;
        }
      
        public async Task<UserTemplate> CreateTempate(int uid, GetTemplateDTO templateDTO)
        {
            if (templateDTO == null)
            {
                throw new Exception($"tempalte is null");
            }

            if (templateDTO.TemplateType != "Email" && templateDTO.TemplateType != "Letter")
            {
                throw new Exception($"type should be Email or Letter");

            }

            var template = new UserTemplate
            {
                UserId = uid,
                TemplateName = templateDTO.TemplateName,
                TemplateContent = templateDTO.TemplateContent,
                TemplateType = templateDTO.TemplateType
            };

            shipmentClaimsContext.UserTemplates.Add(template);
            await shipmentClaimsContext.SaveChangesAsync();

            return template;
        }
        public async Task<UserTemplate> UpdateTemplate(int id, UpdateTemplateDTO templateDTO)
        {
            var templateToUpdate = await shipmentClaimsContext.UserTemplates.FindAsync(id);
            if (templateToUpdate == null)
            {
                throw new Exception($"template is null");


            }
            templateToUpdate.UserId = templateDTO.UserId;
            templateToUpdate.TemplateName = templateDTO.TemplateName;
            templateToUpdate.TemplateContent = templateDTO.TemplateContent;
            templateToUpdate.TemplateType = templateDTO.TemplateType;


            shipmentClaimsContext.UserTemplates.Update(templateToUpdate);
            await shipmentClaimsContext.SaveChangesAsync();

            return templateToUpdate;
        }
        public async Task<UserTemplate> DeleteTemplate(int id)
        {
            var template = await shipmentClaimsContext.UserTemplates.FindAsync(id);
            if (template == null)
            {
                throw new Exception($"template not found");
            }

            shipmentClaimsContext.UserTemplates.Remove(template);
            await shipmentClaimsContext.SaveChangesAsync();

            return template;
        }
    }
}
