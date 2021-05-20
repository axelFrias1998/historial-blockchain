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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace historial_blockchain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HospitalSpecialitiesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HospitalSpecialitiesController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpGet("{hospitalId}")]
        public ActionResult<IEnumerable<HospitalSpecialitiesDTO>> GetHospitalSpecialities(string hospitalId)
        {
            var hospitalSpecialities = context.HospitalEspecialidades.Where(x=> x.HospitalId.Equals(hospitalId))
                .Join(
                    context.SpecialitiesCatalog,
                    x => x.EspecialidadId,
                    y => y.Id,
                    (x, y) => new HospitalSpecialitiesDTO
                    {
                        EspecialidadId = x.EspecialidadId,
                        Nombre = y.Type
                    }
                ).ToList();
            if(hospitalSpecialities is null)
                return NotFound();
            return hospitalSpecialities;
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpGet("{hospitalId}/{specialityId}", Name = "HospitalSpeciality")]
        public async Task<ActionResult<HospitalSpecialitiesDTO>> GetHospitalSpecialitysAsync(string hospitalId, int specialityId)
        {
            var hospitalSpeciality = await context.HospitalEspecialidades.Where(x=> x.HospitalId.Equals(hospitalId))
                .Join(
                    context.SpecialitiesCatalog,
                    x => x.EspecialidadId,
                    y => y.Id,
                    (x, y) => new HospitalSpecialitiesDTO
                    {
                        EspecialidadId = x.EspecialidadId,
                        Nombre = y.Type
                    }
                ).FirstOrDefaultAsync();
            if(hospitalSpeciality is null)
                return NotFound();
            return hospitalSpeciality;
        }



        [Authorize(Roles = "PacsAdmin,ClinicAdmin")]
        [HttpPost]
        public async Task<ActionResult<HospitalSpecialitiesDTO>> AddHospitalSpeciality([FromBody] HospitalSpeciality hospitalSpeciality)
        {
            var newHospitalSpeciality = new HospitalSpeciality{
                EspecialidadId = hospitalSpeciality.EspecialidadId,
                HospitalId = hospitalSpeciality.HospitalId
            };
            var hospitalEspecialidad = mapper.Map<HospitalEspecialidad>(newHospitalSpeciality);
            await context.HospitalEspecialidades.AddAsync(hospitalEspecialidad);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult($"HospitalSpeciality", new { hospitalId = hospitalEspecialidad.HospitalId, specialityId = hospitalEspecialidad.EspecialidadId}, hospitalEspecialidad);
        }

        [Authorize(Roles = "PacsAdmin,ClinicAdmin")]
        [HttpDelete]
        public async Task<ActionResult<HospitalEspecialidad>> RemoveHospitalSpeciality([FromBody] HospitalSpeciality hospitalSpeciality)
        {
            var result = await context.HospitalEspecialidades
                .Where(x => x.EspecialidadId == hospitalSpeciality.EspecialidadId)
                .Where(x => x.HospitalId.Equals(hospitalSpeciality.HospitalId)).FirstOrDefaultAsync();
            
            if(result is null)
                return NotFound();
            
            context.HospitalEspecialidades.Remove(result);
            await context.SaveChangesAsync();
            return result;
        }
    }
}