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

namespace historial_blockchain.Contexts
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SpecialitiesCatalogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SpecialitiesCatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("GetSpecialitiesCatalog")]
        public ActionResult<IEnumerable<SpecialitiesCatalog>>  GetRoles()
        {
            return _context.SpecialitiesCatalog.ToList();
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpPost("CreateSpeciality")]
        public async Task<ActionResult> CreateSpeciality([FromBody] SpecialityName specialityName)
        {
            if(ModelState.IsValid)
            {
                await _context.SpecialitiesCatalog.AddAsync(new SpecialitiesCatalog { Type = specialityName.Name });
                if(await _context.SaveChangesAsync() == 1)
                    return new CreatedAtActionResult("GetSpecialitiesCatalog", "SpecialitiesCatalog", new { type = specialityName.Name}, specialityName);
            }
            ModelState.AddModelError(string.Empty, "Especialidad no pudo ser registrada");
            return BadRequest(ModelState);
        }
    }
}