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
            var hospitalsDto = mapper.Map<List<HospitalsDTO>>(await context.Hospitals.Include(x => x.ServicesCatalog).ToListAsync());
            //var hospitalsDto = mapper.Map<List<HospitalsDTO>>(await context.Hospitals.Include(x => x.ServicesCatalog).Include(x => x.Admin).ToListAsync());
            if(hospitalsDto is null)
                return NotFound();
            return hospitalsDto.ToList();
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpGet("GetHospitalInfo/{id}", Name = "GetHospitalInfo")]
        public async Task<ActionResult<HospitalsDTO>> GetInfo(string id)
        {
            //var query =
            //    from foo in db.Foos
            //    where foo.ID == 45
            //    from bar in foo.Bars
            //    select bar;
            var hospital = mapper.Map<HospitalsDTO>(await context.Hospitals.Include(x => x.ServicesCatalog).FirstOrDefaultAsync(x => x.HospitalId.Equals(id)));
            //var hospital = mapper.Map<HospitalsDTO>(await context.Hospitals.Include(x => x.Admin).Include(x => x.ServicesCatalog).FirstOrDefaultAsync(x => x.HospitalId.Equals(id)));
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
                IsEnable = true
            };
            await context.Hospitals.AddAsync(hospital);
            await context.SaveChangesAsync();

            var hospitalDTO = mapper.Map<CreatedHospitalDTO>(hospital);
            return new CreatedAtRouteResult($"GetHospitalInfo", new { id = hospitalDTO.HospitalId}, hospitalDTO);
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
        [HttpPut("{id}/{enable}")]
        public async Task<ActionResult> PutEnable(string id, bool enable)
        {
            var hospital = await context.Hospitals.FirstOrDefaultAsync(x => x.HospitalId.Equals(id));
            if(hospital is null)
                return NotFound();
            hospital.IsEnable = enable;
            context.Entry(hospital).State = EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] UpdateHospitalDTO updateHospitalDTO)
        {
            var hospital = await context.Hospitals.FirstOrDefaultAsync(x => x.HospitalId.Equals(id));
            if(hospital is null)
                return NotFound();

            hospital.Name = updateHospitalDTO.Name;
            hospital.PhoneNumber = updateHospitalDTO.PhoneNumber;

            context.Entry(hospital).State = EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }
        
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

//TODO PROBAR NUEVAMENTE HOSPITALADMINISTRADOR, HOSPITALSPECIALITIES, HOSPITALDOCTORS Y AGREGAR DOCTORES