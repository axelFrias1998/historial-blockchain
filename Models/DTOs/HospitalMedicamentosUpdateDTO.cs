using System.ComponentModel.DataAnnotations;

namespace historial_blockchain.Models.DTOs
{
    public class HospitalMedicamentosUpdateDTO
    {
        [Required]
        public string NombreMedicamento { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Indicaciones { get; set; }

        [Required]
        public string ViaAdministracion { get; set; }

        [Required]
        public string EfectosSecundarios { get; set; }

        [Required]
        public string Precauciones { get; set; }
    }
}