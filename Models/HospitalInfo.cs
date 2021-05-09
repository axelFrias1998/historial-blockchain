using System.ComponentModel.DataAnnotations;

namespace historial_blockchain.Models
{
    public class HospitalInfo
    {
        [Required]
        [StringLength(150, ErrorMessage = "El nombre debe tener por lo menos tres caracteres y máximo cien", MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public int ServiceCatalogId { get; set; }
    
        [Required]
        public string AdminId { get; set; }
    }
}