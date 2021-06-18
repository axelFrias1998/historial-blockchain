using System.Collections.Generic;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
    public class CatalogoGrupoMedicamentosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CatalogoGrupoMedicamentosController(ApplicationDbContext context, IMapper mapper)
        {   
            this.context = context;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogoGrupoMedicamentos>>> GetGruposMedicamentos()
        {
            var medicamentosCatalog = await context.CatalogoGrupoMedicamentos.ToListAsync();
            if(medicamentosCatalog is null)
                return NotFound();
            return medicamentosCatalog;
        }

        [HttpGet("{id}", Name = "GrupoMedicamentosInfo")]
        public async Task<ActionResult<ListadoGrupoMedicamentosDTO>> GetGrupoMedicamentos(int id)
        {
            var medicamentosCatalog = await context.CatalogoGrupoMedicamentos.FirstOrDefaultAsync(x => x.Id == id);
            if(medicamentosCatalog is null)
                return NotFound();
            return mapper.Map<ListadoGrupoMedicamentosDTO>(medicamentosCatalog);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGrupoMedicamentos([FromBody] ListadoGrupoMedicamentosDTO grupo)
        {
            await context.CatalogoGrupoMedicamentos.AddAsync(new CatalogoGrupoMedicamentos { Type = grupo.Type});
            await context.SaveChangesAsync();
            var grupoMedicamentos = await context.CatalogoGrupoMedicamentos.FirstOrDefaultAsync(x => x.Type.Equals(grupo.Type));
            return new CreatedAtRouteResult("GrupoMedicamentosInfo", new { id = grupoMedicamentos.Id }, grupo);
        }

        [HttpPut("{id}/{newName}")]
        public async Task<ActionResult> Put(int id, string newName)
        {
            var grupoMedicamentos = await context.CatalogoGrupoMedicamentos.FirstOrDefaultAsync(x => x.Id == id);
            if(grupoMedicamentos is null)
                return NotFound();
            grupoMedicamentos.Type = newName;
            context.Entry(grupoMedicamentos).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ListadoGrupoMedicamentosDTO>> Delete(int id)
        {
            var grupoMedicamentos = await context.CatalogoGrupoMedicamentos.FirstOrDefaultAsync(x => x.Id == id);
            if(grupoMedicamentos is null)
                return NotFound();
            context.CatalogoGrupoMedicamentos.Remove(grupoMedicamentos);
            await context.SaveChangesAsync();
            return mapper.Map<ListadoGrupoMedicamentosDTO>(grupoMedicamentos);
        }
    }
}