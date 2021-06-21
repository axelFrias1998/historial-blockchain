using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace historial_blockchain.Models.DTOs
{
    public class CatalogoGrupoMedicamentosDTO
    {
        public int GrupoMedicamentosId { get; set; }

        public string Type { get; set; }

        //public virtual ICollection<Hospital> Hospitals { get; set; }
    }
}