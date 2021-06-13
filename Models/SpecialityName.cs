using System.ComponentModel.DataAnnotations;

namespace historial_blockchain.Models
{
    public class SpecialityName
    {
        [Required]
        public string Name { get; set; }
    }
}