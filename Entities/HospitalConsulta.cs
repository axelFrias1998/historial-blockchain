using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace historial_blockchain.Entities
{
    public class HospitalConsulta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ConsultaId { get; set; }

        public string HospitalId { get; set; }

        public virtual Consulta Consulta { get; set; }

        public virtual Hospital Hospital { get; set; }
    }
}
