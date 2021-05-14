using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using historial_blockchain.Entities;
using Microsoft.AspNetCore.Identity;

namespace historial_blockchain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Hospital")]
        public string HospitalId { get; set; }

        [DataType(DataType.Text)]        
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]        
        [Required(ErrorMessage = "Apellido es requerido")]
        [StringLength(100)]
        public string Apellido { get; set; }

        public virtual Hospital Hospital { get; set; }

        public ICollection<Consulta> Consultas { get; set; }
    }
}