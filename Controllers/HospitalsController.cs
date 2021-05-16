using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using historial_blockchain.Contexts;
using historial_blockchain.Entities;
using historial_blockchain.Models;
using historial_blockchain.Models.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace historial_blockchain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SysAdmin")]
    public class HospitalsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        private readonly UserManager<ApplicationUser> userManager;

        public HospitalsController(ApplicationDbContext context,  UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet("GetCatalogOfServices")]
        public ActionResult<IEnumerable<ServicesCatalog>> GetCatalogOfServices()
        {
            return context.ServicesCatalog.ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hospital>> GetHospitalsInfo()
        {
            return context.Hospitals.Include(x => x.Admin).ToList();
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpGet("GetHospitalInfo/{id}")]
        public ActionResult<Hospital> GetHospitalInfo(string id)
        {
            var hospital = context.Hospitals.Include(x => x.Admin).FirstOrDefault(x => x.HospitalId.Equals(id));
            if(hospital is null)
                return NotFound();
            return hospital;
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpPost]
        public async Task<ActionResult> CreateHospital([FromBody] HospitalInfo hospitalInfo)
        {
            Hospital hospital = new Hospital{
                HospitalId = Guid.NewGuid().ToString(),
                Name = hospitalInfo.Name,
                PhoneNumber = hospitalInfo.PhoneNumber,
                RegisterDate = DateTime.Now,
                ServiceCatalogId = hospitalInfo.ServiceCatalogId,
                AdminId = hospitalInfo.AdminId,
                IsEnable = true
            };
            await context.Hospitals.AddAsync(hospital);
            await context.SaveChangesAsync();
            return new CreatedAtActionResult("GetHospitalInfo/{id}", "Hospitals", new { id = hospital.HospitalId }, hospital);
        }

        [Authorize(Roles = "PacsAdmin,ClinicAdmin")]
        [HttpPost("AddHospitalSpeciality")]
        public async Task<ActionResult> CreateSpeciality([FromBody] HospitalSpeciality hospitalSpecialityDTO)
        {
            if(ModelState.IsValid)
            {
                await context.HospitalEspecialidades.AddAsync(new HospitalEspecialidad{
                    EspecialidadId = hospitalSpecialityDTO.EspecialidadId,
                    HospitalId = hospitalSpecialityDTO.HospitalId
                });
                if(await context.SaveChangesAsync() == 1)
                    return new CreatedAtActionResult("GetSpecialitiesCatalog", "SpecialitiesCatalog", null, null);
            }
            ModelState.AddModelError(string.Empty, "Especialidad no pudo ser asignada al hospital");
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Hospital hospital)
        {
            if(id != hospital.HospitalId)
                return BadRequest();
            context.Entry(hospital).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        /*[HttpPut("AssignAdministrator")]
        public async Task<ActionResult> AssignAdministrator(HospitalAdminDTO hospitalIdentification)
        {
            var hospital = await context.Hospitals.FindAsync(hospitalIdentification.HospitalId);
            if(hospital is null) 
                return BadRequest();
            hospital.AdminId = hospitalIdentification.UserId;
            context.Entry(hospital).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }*/
        
        [HttpDelete("{id}")]
        public ActionResult<Hospital> Delete(string id)
        {
            Hospital hospital = context.Hospitals.FirstOrDefault(x => x.HospitalId.Equals(id));
            
            if(hospital is null)
                return NotFound();
            
            context.Hospitals.Remove(hospital);
            context.SaveChanges();
            return hospital;
        }

    }
}