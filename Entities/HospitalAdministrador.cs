using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using historial_blockchain.Models;

namespace historial_blockchain.Entities
{
    public class HospitalAdministrador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AdminId { get; set; }

        public string HospitalId { get; set; }

        public virtual ApplicationUser Admin { get; set; }

        public virtual Hospital Hospital { get; set; }
    }
}