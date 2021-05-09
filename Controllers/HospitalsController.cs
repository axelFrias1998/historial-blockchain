using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using historial_blockchain.Contexts;
using historial_blockchain.Entities;
using historial_blockchain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace historial_blockchain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SysAdmin")]
    public class HospitalsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public HospitalsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [AllowAnonymous]
        [HttpGet("GetCatalogOfServices")]
        public ActionResult<IEnumerable<ServicesCatalog>> GetCatalogOfServices()
        {
            return context.ServicesCatalog.ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hospital>> GetHospitalsInfo()
        {
            return context.Hospitals.Include(x => x.Admin).ToList();
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpGet("{id}", Name = "GetHospitalInfo")]
        public ActionResult<Hospital> GetHospitalInfo(string id)
        {
            var hospital = context.Hospitals.Include(x => x.Admin).FirstOrDefault(x => x.Id.Equals(id));
            if(hospital is null)
                return NotFound();
            return hospital;
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpPost]
        public ActionResult InsertHospital([FromBody] HospitalInfo hospitalInfo)
        {
            Hospital hospital = new Hospital{
                Id = Guid.NewGuid().ToString(),
                Name = hospitalInfo.Name,
                PhoneNumber = hospitalInfo.PhoneNumber,
                RegisterDate = DateTime.Now,
                ServiceCatalogId = hospitalInfo.ServiceCatalogId,
                AdminId = hospitalInfo.AdminId
            };

            context.Hospitals.Add(hospital);
            context.SaveChanges();
            return new CreatedAtActionResult("GetHospitalInfo", "Hospitals", new { id = hospital.Id }, hospital);
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Hospital hospital)
        {
            if(id != hospital.Id)
                return BadRequest();
            
            context.Entry(hospital).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Hospital> Delete(string id)
        {
            Hospital hospital = context.Hospitals.FirstOrDefault(x => x.Id.Equals(id));
            
            if(hospital is null)
                return NotFound();
            
            context.Hospitals.Remove(hospital);
            context.SaveChanges();
            return hospital;
        }
    }
}