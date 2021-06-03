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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = "SysAdmin")]
    public class SpecialitiesCatalogController : ControllerBase
    {
        private readonly ApplicationDbContext contex;
        private readonly IMapper mapper;

        public SpecialitiesCatalogController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.contex = context;
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialitiesDTO>>>  GetSpecialities()
        {
            var specialitiescatalog = await contex.SpecialitiesCatalog.ToListAsync();
            if(specialitiescatalog is null)
                return NotFound();
            var specialitiesDTO = mapper.Map<List<SpecialitiesDTO>>(specialitiescatalog);
            return specialitiesDTO;
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpGet("{id}", Name = "SpecialityInfo")]
        public async Task<ActionResult<SpecialitiesDTO>> GetSpecialityInfo(int id)
        {
            var specialitiescatalog = await contex.SpecialitiesCatalog.FirstOrDefaultAsync(x => x.Id == id);
            if(specialitiescatalog is null)
                return NotFound();
            return mapper.Map<SpecialitiesDTO>(specialitiescatalog);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSpeciality([FromBody] SpecialityName specialityName)
        {
            await contex.SpecialitiesCatalog.AddAsync(new SpecialitiesCatalog { Type = specialityName.Name });
            await contex.SaveChangesAsync();
            var speciality = await contex.SpecialitiesCatalog.FirstOrDefaultAsync(x => x.Type.Equals(specialityName.Name));
            return new CreatedAtRouteResult("SpecialityInfo", new { id = speciality.Id}, specialityName);
        }

        [HttpPut("{id}/{newName}")]
        public async Task<ActionResult> Put(int id, string newName)
        {
            var speciality = await contex.SpecialitiesCatalog.FirstOrDefaultAsync(x => x.Id == id);
            if(speciality is null)
                return NotFound();
            speciality.Type = newName;
            contex.Entry(speciality).State = EntityState.Modified;
            await contex.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecialitiesDTO>> Delete(int id)
        {
            var speciality = await contex.SpecialitiesCatalog.FirstOrDefaultAsync(x => x.Id == id);
            if(speciality is null)
                return NotFound();
            contex.SpecialitiesCatalog.Remove(speciality);
            await contex.SaveChangesAsync();
            return mapper.Map<SpecialitiesDTO>(speciality);
        }
    }
}