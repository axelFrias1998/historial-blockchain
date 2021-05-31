using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using historial_blockchain.Models;
using Microsoft.AspNetCore.Identity;

namespace historial_blockchain.Entities
{
    public class Consulta
    {
        public Consulta()
        {
            this.Hospitals = new List<Hospital>();
        }
        
        [Key]
        public string ConsultaId { get; set; }

        [Required]
        public DateTime DateStamp { get; set; }

        [ForeignKey("Paciente")]
        public string PacienteId { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }

        public virtual ApplicationUser Paciente { get; set; }

        public virtual ApplicationUser Doctor { get; set; }

        public virtual ICollection<Hospital> Hospitals { get; set ;}

    }
}