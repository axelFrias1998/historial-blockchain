using System.ComponentModel.DataAnnotations;

namespace historial_blockchain.Models
{
    public class HospitalAdmin
    {
        [Required]
        public string AdminId { get; set; }

        [Required]
        public string HospitalId { get; set; }
    }
}