using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using historial_blockchain.Models;
using Microsoft.AspNetCore.Identity;

namespace historial_blockchain.Entities
{
    public class Hospital
    {
        public Hospital()
        {
            this.Doctors = new List<ApplicationUser>();
            this.Especialidades = new List<SpecialitiesCatalog>();
            this.Consultas = new List<Consulta>();
        }

        [Key]
        public string HospitalId { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        [Phone, Required, StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [Required, ForeignKey("ServicesCatalog")]
        public int ServiceCatalogId { get; set; }

        [Required, ForeignKey("Admin")]
        public string AdminId { get; set; }

        public bool IsEnable { get; set; }

        public virtual ServicesCatalog ServicesCatalog { get; set; }

        public virtual ApplicationUser Admin { get; set; }

        public virtual ICollection<ApplicationUser> Doctors { get; set; }

        public virtual ICollection<SpecialitiesCatalog> Especialidades { get; set ; }

        public virtual ICollection<Consulta> Consultas { get; set ; }
    }
}