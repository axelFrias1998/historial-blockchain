using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace historial_blockchain.Entities
{
    public class HospitalEspecialidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EspecialidadId { get; set; }

        public string HospitalId { get; set; }

        public virtual SpecialitiesCatalog Especialidad { get; set; }

        public virtual Hospital Hospital { get; set; }
    }
}
