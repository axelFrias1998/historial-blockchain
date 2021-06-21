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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
    public class HospitalSpecialitiesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HospitalSpecialitiesController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("{hospitalId}")]
        public async Task<ActionResult<IEnumerable<HospitalSpecialitiesDTO>>> GetHospitalSpecialities(string hospitalId)
        {
            var hospitalSpeciality = await context.HospitalEspecialidades.Where(x=> x.HospitalId.Equals(hospitalId))
                .Join(
                    context.SpecialitiesCatalog,
                    x => x.EspecialidadId,
                    y => y.Id,
                    (x, y) => new HospitalSpecialitiesDTO
                    {
                        Id = x.EspecialidadId,
                        Type = y.Type
                    }
                ).ToListAsync();
            if(hospitalSpeciality is null)
                return NotFound();
            return hospitalSpeciality;
        }
        
        [HttpGet("HospitalSpeciality/{hospitalId}/{specialityId}", Name = "HospitalSpeciality")]
        public async Task<ActionResult<HospitalSpecialitiesDTO>> GetHospitalSpeciality(string hospitalId, int specialityId)
        {
            var hospitalSpeciality = await context.HospitalEspecialidades.Where(x=> x.HospitalId.Equals(hospitalId)).Where(x => x.EspecialidadId == specialityId)
                .Join(
                    context.SpecialitiesCatalog,
                    x => x.EspecialidadId,
                    y => y.Id,
                    (x, y) => new HospitalSpecialitiesDTO
                    {
                        Id = x.EspecialidadId,
                        Type = y.Type
                    }
                ).FirstOrDefaultAsync();
            if(hospitalSpeciality is null)
                return NotFound();
            return hospitalSpeciality;
        }

        [HttpPost]
        public async Task<ActionResult<HospitalSpecialitiesDTO>> AddHospitalSpeciality([FromBody] HospitalSpeciality hospitalSpeciality)
        {
            var newHospitalSpeciality = new HospitalEspecialidad{
                EspecialidadId = hospitalSpeciality.EspecialidadId,
                HospitalId = hospitalSpeciality.HospitalId
            };
            await context.HospitalEspecialidades.AddAsync(newHospitalSpeciality);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("HospitalSpeciality", new { hospitalId = newHospitalSpeciality.HospitalId, specialityId = newHospitalSpeciality.EspecialidadId}, newHospitalSpeciality);
        }

        [HttpDelete("{hospitalId}/{specialityId}")]
        public async Task<ActionResult<HospitalEspecialidad>> RemoveHospitalSpeciality(string hospitalId, int specialityId)
        {
            var result = await context.HospitalEspecialidades
                .Where(x => x.EspecialidadId == specialityId)
                .Where(x => x.HospitalId.Equals(hospitalId)).FirstOrDefaultAsync();
            
            if(result is null)
                return NotFound();
            
            context.HospitalEspecialidades.Remove(result);
            await context.SaveChangesAsync();
            return result;
        }
    }
}
