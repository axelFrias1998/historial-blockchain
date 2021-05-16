using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace historial_blockchain.Entities
{
    public class SpecialitiesCatalog
    {
        public SpecialitiesCatalog()
        {
            this.Hospitals = new List<Hospital>();
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Hospital> Hospitals { get; set; }
    }
}