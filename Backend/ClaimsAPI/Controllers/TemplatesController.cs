using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClaimsAPI.Models;
using ClaimsAPI.Models.Entities;
using ClaimsAPI.Models.ViewModels;
namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {


        private readonly ShipmentClaimsContext _dbContext;
        public TemplatesController(ShipmentClaimsContext dbContext)
        {
            _dbContext = dbContext;
        }




        [HttpGet]
        public async Task<IActionResult> GetTemplate(int id)
        {
            var template = await _dbContext.UserTemplates
                .Where(p => p.UserId == id)
                .Select(p => new GetTemplateDTO
                {
                   TemplateName = p.TemplateName,
                   TemplateType = p.TemplateType,
                   TemplateContent = p.TemplateContent
                }).FirstOrDefaultAsync();

            if (template == null)
            {
                return NotFound();
            }

            return Ok(template);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTempate(int uid, GetTemplateDTO templateDTO)
        {
            if (templateDTO == null)
            {
                return BadRequest("template is null.");
            }
            
            if (templateDTO.TemplateType != "Email" && templateDTO.TemplateType != "Letter")
            {
                return BadRequest("templatetype should be Email or Letter.");

            }

            var template = new UserTemplate
            {    
                UserId = uid,
               TemplateName = templateDTO.TemplateName,
               TemplateContent = templateDTO.TemplateContent,
               TemplateType=templateDTO.TemplateType
            };

            _dbContext.UserTemplates.Add(template);
            await _dbContext.SaveChangesAsync();

            return Ok(template);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePermission(int id, UpdateTemplateDTO templateDTO)
        {
            var templateToUpdate = await _dbContext.UserTemplates.FindAsync(id);
            if (templateToUpdate == null)
            {
                return NotFound("template not found.");
            }
            templateToUpdate.UserId = templateDTO.UserId;
            templateToUpdate.TemplateName = templateDTO.TemplateName;
            templateToUpdate.TemplateContent = templateDTO.TemplateContent;
            templateToUpdate.TemplateType = templateDTO.TemplateType;


            _dbContext.UserTemplates.Update(templateToUpdate);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var template = await _dbContext.UserTemplates.FindAsync(id);
            if (template == null)
            {
                return NotFound("template not found.");
            }

            _dbContext.UserTemplates.Remove(template);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }





    }
}
