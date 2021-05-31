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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CatalogoGrupoMedicamentosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CatalogoGrupoMedicamentosController(ApplicationDbContext context, IMapper mapper)
        {   
            this.context = context;
            this.mapper = mapper;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListadoGrupoMedicamentosDTO>>> GetGruposMedicamentos()
        {
            var medicamentosCatalog = await context.CatalogoGrupoMedicamentos.ToListAsync();
            if(medicamentosCatalog is null)
                return NotFound();
            var medicamentosCatalogDTO = mapper.Map<List<ListadoGrupoMedicamentosDTO>>(medicamentosCatalog);
            return medicamentosCatalogDTO;
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpGet("{id}", Name = "GrupoMedicamentosInfo")]
        public async Task<ActionResult<ListadoGrupoMedicamentosDTO>> GetGrupoMedicamentos(int id)
        {
            var medicamentosCatalog = await context.CatalogoGrupoMedicamentos.FirstOrDefaultAsync(x => x.Id == id);
            if(medicamentosCatalog is null)
                return NotFound();
            return mapper.Map<ListadoGrupoMedicamentosDTO>(medicamentosCatalog);
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpPost]
        public async Task<ActionResult> CreateGrupoMedicamentos([FromBody] ListadoGrupoMedicamentosDTO grupo)
        {
            await context.CatalogoGrupoMedicamentos.AddAsync(new CatalogoGrupoMedicamentos { Type = grupo.Type});
            await context.SaveChangesAsync();
            var grupoMedicamentos = await context.CatalogoGrupoMedicamentos.FirstOrDefaultAsync(x => x.Type.Equals(grupo.Type));
            return new CreatedAtRouteResult("GrupoMedicamentosInfo", new { id = grupoMedicamentos.Id }, grupo);
        }

        [Authorize(Roles = "SysAdmin")]
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

        [Authorize(Roles = "SysAdmin")]
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