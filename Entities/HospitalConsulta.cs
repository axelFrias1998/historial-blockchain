using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using historial_blockchain.Models;

namespace historial_blockchain.Entities
{
    public class HospitalConsulta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsultaId { get; set; }

        [Required]
        public DateTime DateStamp { get; set; }

        [ForeignKey("Paciente")]
        public string PacienteId { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }

        [ForeignKey("Hospital")]
        public string HospitalId { get; set; }

        public virtual ApplicationUser Paciente { get; set; }

        public virtual ApplicationUser Doctor { get; set; }

        public virtual Hospital Hospital { get; set; }
    }
}