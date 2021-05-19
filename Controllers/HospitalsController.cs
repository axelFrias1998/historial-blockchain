using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper mapper;

        public HospitalsController(ApplicationDbContext context,  UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalsDTO>>> GetHospitalsInfo()
        {
            var hospitalsDto = mapper.Map<List<HospitalsDTO>>(await context.Hospitals.Include(x => x.ServicesCatalog).Include(x => x.Admin).ToListAsync());
            if(hospitalsDto is null)
                return NotFound();
            return hospitalsDto.ToList();
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpGet("{id}", Name = "GetHospitalInfo")]
        public async Task<ActionResult<HospitalsDTO>> GetInfo(string id)
        {
            var hospital = mapper.Map<HospitalsDTO>(await context.Hospitals.Include(x => x.Admin).Include(x => x.ServicesCatalog).FirstOrDefaultAsync(x => x.HospitalId.Equals(id)));
            if(hospital is null)
                return NotFound();
            return hospital;
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpPost]
        public async Task<ActionResult<CreatedHospitalDTO>> CreateHospital([FromBody] HospitalInfo hospitalInfo)
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

            var hospitalDTO = mapper.Map<CreatedHospitalDTO>(hospital);
            return new CreatedAtRouteResult($"GetHospitalInfo", new { id = hospitalDTO.HospitalId}, hospitalDTO);
        }

        //TODO Probar con un Pacs Admin y un Clinic admin
        [Authorize(Roles = "PacsAdmin,ClinicAdmin")]
        [HttpPost("AddSpeciality")]
        public async Task<ActionResult> AddSpeciality([FromBody] HospitalSpeciality hospitalSpecialityDTO)
        {
            if(ModelState.IsValid)
            {
                await context.HospitalEspecialidades.AddAsync(new HospitalEspecialidad{
                    EspecialidadId = hospitalSpecialityDTO.EspecialidadId,
                    HospitalId = hospitalSpecialityDTO.HospitalId
                });
                return new CreatedAtRouteResult($"GetSpecialities", new { id = hospitalSpecialityDTO.HospitalId}, hospitalSpecialityDTO);
            }
            ModelState.AddModelError(string.Empty, "Especialidad no pudo ser asignada al hospital");
            return BadRequest(ModelState);
        }


        [HttpGet("GetSpecialities/{id}", Name = "GetSpecialities")]
        public async Task<ActionResult<IEnumerable<HospitalEspecialidad>>> GetSpecialities(string id)
        {
            var catalogOfSpecialities = await context.HospitalEspecialidades.Where(x => x.HospitalId.Equals(id)).Include(x => x.Especialidad).ThenInclude(x => x.Type).ToListAsync();
            if(catalogOfSpecialities is null)
                return NotFound();
            return catalogOfSpecialities;
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpPut("HospitalEnable/{id}/{enable}")]
        public async Task<ActionResult> Put(string id, bool enable)
        {
            var hospital = await context.Hospitals.FirstOrDefaultAsync(x => x.HospitalId.Equals(id));
            if(hospital is null)
                return NotFound();
            hospital.IsEnable = enable;
            context.Entry(hospital).State = EntityState.Modified;
            context.SaveChanges();
            return NoContent();
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
        
        [Authorize(Roles = "SysAdmin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hospital>> Delete(string id)
        {
            Hospital hospital = await context.Hospitals.FirstOrDefaultAsync(x => x.HospitalId.Equals(id));
            
            if(hospital is null)
                return NotFound();
            
            context.Hospitals.Remove(hospital);
            context.SaveChanges();
            return hospital;
        }

    }
}