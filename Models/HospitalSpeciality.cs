using System.ComponentModel.DataAnnotations;

namespace historial_blockchain.Models
{
    public class HospitalSpeciality
    {
        public int EspecialidadId { get; set; }

        [MinLength(32)]
        public string HospitalId { get; set; }
    }
}