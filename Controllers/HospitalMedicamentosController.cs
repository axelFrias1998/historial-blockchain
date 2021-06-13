using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using historial_blockchain.Contexts;
using historial_blockchain.Entities;
using historial_blockchain.Models.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace historial_blockchain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PacsAdmin,ClinicAdmin")]
    public class HospitalMedicamentosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HospitalMedicamentosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;  
            this.mapper = mapper;
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{hospitalId}")]
        public async Task<ActionResult<IEnumerable<HospitalMedicamentosDTO>>> GetHospitalMedicamentos(string hospitalId)
        {
            var hospitalMedicamentos = await context.HospitalMedicamentos.Where(x => x.HospitalId.Equals(hospitalId))
                .Join(
                    context.CatalogoGrupoMedicamentos,
                    x => x.GrupoMedicamentosId,
                    y => y.Id,
                    (x, y) => new HospitalMedicamentosDTO
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Indicaciones = x.Indicaciones,
                        ViaAdministracion = x.ViaAdministracion,
                        GrupoMedicamentos = y.Type,
                        EfectosSecundarios = x.EfectosSecundarios,
                        NombreMedicamento = x.NombreMedicamento,
                        Precauciones = x.Precauciones
                    }
                ).ToListAsync();
            if(hospitalMedicamentos is null)
                return NotFound();
            return hospitalMedicamentos;
        }

        [HttpGet("{hospitalId}/{medicamentoId}")]
        public async Task<ActionResult<HospitalMedicamentosDTO>> GetHospitalMedicamentos(string hospitalId, int medicamentoId)
        {
            var hospitalMedicamentos = await context.HospitalMedicamentos.Where(x => x.HospitalId.Equals(hospitalId)).Where(x => x.Id == medicamentoId)
                .Join(
                    context.CatalogoGrupoMedicamentos,
                    x => x.GrupoMedicamentosId,
                    y => y.Id,
                    (x, y) => new HospitalMedicamentosDTO
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Indicaciones = x.Indicaciones,
                        ViaAdministracion = x.ViaAdministracion,
                        GrupoMedicamentos = y.Type,
                        EfectosSecundarios = x.EfectosSecundarios,
                        NombreMedicamento = x.NombreMedicamento,
                        Precauciones = x.Precauciones
                    }
                ).FirstOrDefaultAsync();
            if(hospitalMedicamentos is null)
                return NotFound();
            return hospitalMedicamentos;
        }

        [HttpPost]
        public async Task<ActionResult<HospitalMedicamentosDTO>> AddHospitalMedicamentos([FromBody] HospitalMedicamentosCreateDTO hospitalMedicamentosCreateDTO)
        {
            var medExists = await context.HospitalMedicamentos.FirstOrDefaultAsync(x => x.HospitalId.Equals(hospitalMedicamentosCreateDTO.HospitalId) && x.NombreMedicamento.Equals(hospitalMedicamentosCreateDTO.NombreMedicamento.ToUpper()));
            if(medExists is not null)
                return BadRequest();
            var hospitalMedicamento = new HospitalMedicamentos{
                HospitalId = hospitalMedicamentosCreateDTO.HospitalId,
                Descripcion = hospitalMedicamentosCreateDTO.Descripcion.ToUpper(),
                ViaAdministracion = hospitalMedicamentosCreateDTO.ViaAdministracion,
                Indicaciones = hospitalMedicamentosCreateDTO.Indicaciones,
                NombreMedicamento = hospitalMedicamentosCreateDTO.NombreMedicamento.ToUpper(),
                GrupoMedicamentosId = hospitalMedicamentosCreateDTO.GrupoMedicamentosId,
                Precauciones = hospitalMedicamentosCreateDTO.Precauciones,
                EfectosSecundarios = hospitalMedicamentosCreateDTO.EfectosSecundarios
            };
            await context.HospitalMedicamentos.AddAsync(hospitalMedicamento);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] HospitalMedicamentosUpdateDTO hospitalMedicamentosUpdateDTO)
        {
            var hospitalMedicamento = await context.HospitalMedicamentos.FirstOrDefaultAsync(x => x.Id == id);
            if(hospitalMedicamento is null)
                return NotFound();
            hospitalMedicamento.Descripcion = hospitalMedicamentosUpdateDTO.Descripcion;
            hospitalMedicamento.Indicaciones = hospitalMedicamentosUpdateDTO.Indicaciones;
            hospitalMedicamento.ViaAdministracion = hospitalMedicamentosUpdateDTO.ViaAdministracion;
            hospitalMedicamento.NombreMedicamento = hospitalMedicamentosUpdateDTO.NombreMedicamento;
            hospitalMedicamento.EfectosSecundarios = hospitalMedicamentosUpdateDTO.EfectosSecundarios;
            hospitalMedicamento.Precauciones = hospitalMedicamentosUpdateDTO.Precauciones;
            context.Entry(hospitalMedicamento).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<HospitalMedicamentosUpdateDTO>> Delete(int id)
        {   
            var hospitalMedicamento = await context.HospitalMedicamentos.FirstOrDefaultAsync(x => x.Id == id);
            if(hospitalMedicamento is null)
                return NotFound();
            context.HospitalMedicamentos.Remove(hospitalMedicamento);
            await context.SaveChangesAsync();
            return mapper.Map<HospitalMedicamentosUpdateDTO>(hospitalMedicamento);
        }

    }
}