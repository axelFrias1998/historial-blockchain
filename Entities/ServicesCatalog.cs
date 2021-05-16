using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace historial_blockchain.Entities
{
    public class ServicesCatalog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        //True for public hospitals and clinics
        public bool IsPublic { get; set; }
    }
}