using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace historial_blockchain.Entities
{
    public class HospitalMedicamentos 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public string Indicaciones { get; set; }

        public string ViaAdministracion { get; set; }

        [ForeignKey("CatalogoGrupoMedicamentos")]
        public int GrupoMedicamentosId { get; set; }

        [ForeignKey("Hospital")]
        public string HospitalId { get; set; }

        public virtual Hospital Hospital { get; set; }

        public virtual CatalogoGrupoMedicamentos CatalogoGrupoMedicamentos { get; set; }
    }
}