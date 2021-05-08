using System;
using System.Collections.Generic;
using System.Linq;
using historial_blockchain.Contexts;
using historial_blockchain.Entities;
using historial_blockchain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace historial_blockchain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public HospitalsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hospital>> GetHospitalsInfo()
        {
            return context.Hospitals.ToList();
        }

        [HttpGet("{id}", Name = "GetHospitalInfo")]
        public ActionResult<Hospital> GetHospitalInfo(string id)
        {
            var hospital = context.Hospitals.FirstOrDefault(x => x.Id.Equals(id));
            if(hospital is null)
                return NotFound();
            return hospital;
        }

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