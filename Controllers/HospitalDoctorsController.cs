using System.Collections.Generic;
using AutoMapper;
using historial_blockchain.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace historial_blockchain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HospitalDoctorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HospitalDoctorsController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        /*[Authorize(Roles = "PacsAdmin,ClinicAdmin")]
        [HttpGet("{hospitalId}")]
        public ActionResult<IEnumerable<HospitalDoctorsDTO>> GetHospitalSpecialities(string hospitalId)
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
        }*/
        //TODO agregar doctores, leerlos, eliminarlos y obtener por id
    }
}