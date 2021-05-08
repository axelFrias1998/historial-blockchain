using System.ComponentModel.DataAnnotations;

namespace historial_blockchain.Models
{
    public class HospitalInfo
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int ServiceCatalogId { get; set; }
        
        [Required]
        public string AdminId { get; set; }
    }
}