using System.ComponentModel.DataAnnotations;

namespace historial_blockchain.Models
{
    public class HospitalSpeciality
    {
        [Required]
        public int EspecialidadId { get; set; }

        [Required]
        public string HospitalId { get; set; }
    }
}