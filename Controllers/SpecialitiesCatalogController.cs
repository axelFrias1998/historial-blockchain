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

namespace historial_blockchain.Contexts
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SpecialitiesCatalogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public SpecialitiesCatalogController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialitiesDTO>>>  GetSpecialities()
        {
            var specialitiescatalog = await _context.SpecialitiesCatalog.ToListAsync();
            if(specialitiescatalog is null)
                return NotFound();
            var specialitiesDTO = mapper.Map<List<SpecialitiesDTO>>(specialitiescatalog);
            return specialitiesDTO;
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpGet("{id}", Name = "SpecialityInfo")]
        public async Task<ActionResult<SpecialitiesDTO>> GetSpecialityInfo(int id)
        {
            var specialitiescatalog = await _context.SpecialitiesCatalog.FirstOrDefaultAsync(x => x.Id == id);
            if(specialitiescatalog is null)
                return NotFound();
            var specialityDTO = mapper.Map<SpecialitiesDTO>(specialitiescatalog);
            if(specialityDTO is null)
                return NotFound();
            return specialityDTO;
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpPost]
        public async Task<ActionResult> CreateSpeciality([FromBody] SpecialityName specialityName)
        {
            await _context.SpecialitiesCatalog.AddAsync(new SpecialitiesCatalog { Type = specialityName.Name });
            await _context.SaveChangesAsync();
            var speciality = await _context.SpecialitiesCatalog.FirstOrDefaultAsync(x => x.Type.Equals(specialityName.Name));
            return new CreatedAtRouteResult("SpecialityInfo", new { id = speciality.Id}, specialityName);
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpPut("{id}/{newName}")]
        public async Task<ActionResult> Put(int id, string newName)
        {
            var speciality = await _context.SpecialitiesCatalog.FirstOrDefaultAsync(x => x.Id == (id));
            if(speciality is null)
                return NotFound();
            speciality.Type = newName;
            _context.Entry(speciality).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecialitiesDTO>> Delete(int id)
        {
            var speciality = await _context.SpecialitiesCatalog.FirstOrDefaultAsync(x => x.Id == (id));
            if(speciality is null)
                return NotFound();
            _context.SpecialitiesCatalog.Remove(speciality);
            await _context.SaveChangesAsync();
            return mapper.Map<SpecialitiesDTO>(speciality);
        }

        //TODO probar edición y agregado de especialidades
    }
}