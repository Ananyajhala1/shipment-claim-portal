using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using ClaimsAPI.Service.TemplatesService;
namespace ClaimsAPI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {


        private readonly ITemplateService _TemplateService;
        public TemplatesController(ITemplateService templateService)
        {
            _TemplateService = templateService;
        }


        [HttpGet]
        public async Task<IActionResult> GetTemplate(int id)
        {

            var TemplateService = await _TemplateService.GetTemplate(id);
            if (TemplateService == null)
            {
                return NotFound();
            }
            return Ok(TemplateService);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTempate(int uid, GetTemplateDTO templateDTO)
        {
        var TemplateService = await _TemplateService.CreateTempate(uid, templateDTO);
        if (TemplateService == null)
        {
            return NotFound();
        }
        return Ok(TemplateService);

       
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTemplate(int id, UpdateTemplateDTO templateDTO)
        {
        var TemplateService = await _TemplateService.UpdateTemplate(id, templateDTO);
        if (TemplateService == null)
        {
            return NotFound();
        }
        return Ok(TemplateService);

    }

    [HttpDelete()]
        public async Task<IActionResult> DeleteTemplate(int id)
        {
        var TemplateService = await _TemplateService.DeleteTemplate(id);
        if (TemplateService == null)
        {
            return NotFound();
        }
        return Ok(TemplateService);

    }





}


