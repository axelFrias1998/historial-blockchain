using System.Collections.Generic;
using System.Linq;
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

namespace historial_blockchain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "PacsAdmin,ClinicAdmin")]
    public class HospitalDoctorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public HospitalDoctorsController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet("{hospitalId}")]
        public ActionResult<IEnumerable<HospitalDoctorsInfoDTO>> GetDoctors(string hospitalId)
        {
            var hospitalsdoctors = from HD in context.HospitalDoctor
                                    join U in context.Users on HD.DoctorId equals U.Id
                                    join SC in context.SpecialitiesCatalog on HD.EspecialidadId equals SC.Id
                                    where HD.HospitalId == hospitalId
                                    select new HospitalDoctorsInfoDTO
                                    {
                                        DoctorId = U.Id,
                                        Nombre = U.Nombre,
                                        Apellido = U.Apellido,
                                        Email = U.Email,
                                        Numero = U.PhoneNumber,
                                        Especialidad = SC.Type
                                    };
            if(hospitalsdoctors is null)
                return NotFound();
            return hospitalsdoctors.ToList();
        }

        [HttpDelete("{hospitalId}/{doctorId}")]
        public async Task<ActionResult<HospitalDoctor>> DeleteDoctor(string hospitalId, string doctorId)
        {
            var hospitalDoctor = await context.HospitalDoctor.FirstOrDefaultAsync(x => x.DoctorId.Equals(doctorId) && x.HospitalId.Equals(hospitalId));
            if(hospitalDoctor is null)
                return NotFound();
            context.HospitalDoctor.Remove(hospitalDoctor);
            await context.SaveChangesAsync();

            var doctor = await userManager.FindByIdAsync(doctorId);
            await userManager.DeleteAsync(doctor);

            return hospitalDoctor;
        }

        [HttpPut("{hospitalId}/{doctorId}/{especialidadId}")]
        public async Task<ActionResult<HospitalDoctor>> UpdateDoctorSpeciality(string hospitalId, string doctorId, int especialidadId)
        {
            var hospitalSpeciality = await context.HospitalEspecialidades.FirstOrDefaultAsync(x => x.HospitalId.Equals(hospitalId) && x.EspecialidadId == especialidadId);//FirstOrDefaultAsync(x => x.EspecialidadId == especialidadId && x.HospitalId.Equals(hospitalId));
            if(hospitalSpeciality is null)
                return BadRequest("El hospital no cuenta con esa especialidad");

            var hospitalDoctor = await context.HospitalDoctor.FirstOrDefaultAsync(x => x.DoctorId.Equals(doctorId) && x.HospitalId.Equals(hospitalId));
            if(hospitalDoctor is null)
                return NotFound();
            
            hospitalDoctor.EspecialidadId = especialidadId;
            context.Entry(hospitalDoctor).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}