using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace historial_blockchain.Entities
{
    public class SpecialitiesCatalog
    {
        public SpecialitiesCatalog()
        {
            this.Hospitals = new List<Hospital>();
        }
        
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Hospital> Hospitals { get; set; }
    }
}