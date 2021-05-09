using System.ComponentModel.DataAnnotations;

namespace historial_blockchain.Entities
{
    public class ServicesCatalog
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        //True for public hospitals and clinics
        public bool IsPublic { get; set; }
    }
}