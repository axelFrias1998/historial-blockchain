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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        //TODO PROBAR JOIN DE BÚSQUEDA DE ADMINISTRADORES
        [Authorize(Roles = "SysAdmin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalsDTO>>> GetHospitalsInfo()
        {
            var hospitalsDTO = mapper.Map<List<HospitalsDTO>>(await context.Hospitals.Include(x => x.ServicesCatalog).ToListAsync());
            foreach (var hospital in hospitalsDTO)
            {
                var admins = from HA in context.HospitalAdministrador
                             join U in context.Users on HA.AdminId equals U.Id
                             where HA.HospitalId == hospital.HospitalId
                             select new CreatedUserDTO{
                                 Id = U.Id,
                                 Nombre = U.Nombre,
                                 Apellido = U.Apellido,
                                 UserName = U.UserName,
                                 Email = U.Email,
                                 PhoneNumber = U.PhoneNumber
                             };
                foreach (var admin in admins)
                    hospital.Admins.Add(admin);
                var especialidades = from HE in context.HospitalEspecialidades
                            join S in context.SpecialitiesCatalog on HE.EspecialidadId equals S.Id
                            where HE.HospitalId == hospital.HospitalId
                            select new SpecialitiesDTO{
                                Id = S.Id,
                                Type = S.Type
                            };
                foreach (var especialidad in especialidades)
                    hospital.Especialidades.Add(especialidad);
            }
            if(hospitalsDTO is null)
                return NotFound();
            return hospitalsDTO;
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpGet("GetHospitalInfo/{id}", Name = "GetHospitalInfo")]
        public async Task<ActionResult<HospitalsDTO>> GetInfo(string id)
        {
            var hospitalDTO = mapper.Map<HospitalsDTO>(await context.Hospitals.Include(x => x.ServicesCatalog).FirstOrDefaultAsync(x => x.HospitalId.Equals(id)));
            if(hospitalDTO is null)
                return NotFound();
            var admins = from HA in context.HospitalAdministrador
                        join U in context.Users on HA.AdminId equals U.Id
                        where HA.HospitalId == hospitalDTO.HospitalId
                        select new CreatedUserDTO{
                            Id = U.Id,
                            Nombre = U.Nombre,
                            Apellido = U.Apellido,
                            UserName = U.UserName,
                            Email = U.Email,
                            PhoneNumber = U.PhoneNumber
                        };
            foreach (var admin in admins)
                hospitalDTO.Admins.Add(admin);

            var especialidades = from HE in context.HospitalEspecialidades
                                join S in context.SpecialitiesCatalog on HE.EspecialidadId equals S.Id
                                where HE.HospitalId == hospitalDTO.HospitalId
                                select new SpecialitiesDTO{
                                    Id = S.Id,
                                    Type = S.Type
                                };
            foreach (var especialidad in especialidades)
                hospitalDTO.Especialidades.Add(especialidad);
            return hospitalDTO;
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