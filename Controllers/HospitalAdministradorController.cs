using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using historial_blockchain.Contexts;
using historial_blockchain.Data;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SysAdmin")]
    public class HospitalAdministradorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly HospitalAdministradoresRepository repository;

        public HospitalAdministradorController(ApplicationDbContext context, IMapper mapper, HospitalAdministradoresRepository repository)
        {
            this.context = context;
            this.mapper = mapper;
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("AvailableAdmins/{type}")]
        public async Task<ActionResult<IEnumerable<HospitalAdminDTO>>> GetAvailableAdmins(bool type)
        {
            return await repository.GetAvailableAdmins((type) ? "PacsAdmin" : "ClinicAdmin");
        }

        
        [HttpGet("{hospitalId}")]
        public async Task<ActionResult<IEnumerable<HospitalAdminDTO>>> GetHospitalAdmins(string hospitalId)
        {
            var info = new HospitalAdminCreatedDTO();
            var hospitalAdmins = await context.HospitalAdministrador.Where(x => x.HospitalId.Equals(hospitalId))
                .Join(
                    context.Users,
                    x => x.AdminId,
                    y => y.Id,
                    (x, y) => new HospitalAdminDTO{
                        AdminId = x.AdminId,
                        Nombre = y.Nombre,
                        Apellido = y.Apellido
                    }
                )
            .ToListAsync();
            if(hospitalAdmins is null)
                return NotFound();
            return hospitalAdmins;
        }

        [HttpGet("HospitalAdminAdded/{hospitalId}/{adminId}", Name = "HospitalAdminAdded")]
        public async Task<ActionResult<HospitalAdminCreatedDTO>> GetHospitalAdminAdded(string hospitalId, string adminId)
        {
            var info = new HospitalAdminCreatedDTO();
            var hospitalAdmin = await context.HospitalAdministrador.Where(x => x.HospitalId.Equals(hospitalId)).Where(x => x.AdminId.Equals(adminId))
                .Join(
                    context.Users,
                    x => x.AdminId,
                    y => y.Id,
                    (x, y) => new HospitalAdminDTO{
                        AdminId = x.AdminId,
                        Nombre = y.Nombre,
                        Apellido = y.Apellido
                    }
                )
            .FirstOrDefaultAsync();
            if(hospitalAdmin is null)
                return NotFound();

            var hospitalInfo = await context.HospitalAdministrador.Where(x => x.HospitalId.Equals(hospitalId)).Where(x => x.AdminId.Equals(adminId))
                .Join(
                    context.Hospitals,
                    x => x.AdminId,
                    y => y.HospitalId,
                    (x, y) => new HospitalAdminCreatedDTO{
                        HospitalId = x.HospitalId,
                        Nombre = y.Name,
                    }
                )
            .FirstOrDefaultAsync();
            if(hospitalInfo is null)
                return NotFound();

            else return new HospitalAdminCreatedDTO{
                HospitalId = hospitalInfo.HospitalId,
                HospitalName = hospitalInfo.Nombre,
                AdminId = hospitalAdmin.AdminId,
                Apellido = hospitalAdmin.Apellido,
                Nombre = hospitalAdmin.Nombre
            };
        }

        [HttpPost]
        public async Task<ActionResult<HospitalSpecialitiesDTO>> AddAdmin([FromBody] HospitalAdmin hospitalAdmin)
        {
            var hospitalAdministrador = new HospitalAdministrador()
            {
                HospitalId = hospitalAdmin.HospitalId,
                AdminId = hospitalAdmin.AdminId
            };
            await context.HospitalAdministrador.AddAsync(hospitalAdministrador);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult($"HospitalAdminAdded", new { hospitalId = hospitalAdmin.HospitalId, adminId = hospitalAdmin.AdminId}, hospitalAdmin);
        }

        //Probar eliminar administradores de tabla usuarios
        [HttpDelete]
        public async Task<ActionResult<HospitalAdministrador>> RemoveHospitalAdmin([FromBody] HospitalAdmin hospitalAdmin)
        {
            var result = await context.HospitalAdministrador
                .Where(x => x.AdminId.Equals(hospitalAdmin.AdminId))
                .Where(x => x.HospitalId.Equals(hospitalAdmin.HospitalId)).FirstOrDefaultAsync();
            
            if(result is null)
                return NotFound();
            
            context.HospitalAdministrador.Remove(result);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}