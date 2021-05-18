using System;

namespace historial_blockchain.Models.DTOs
{
    public class HospitalsDTO
    {
        public string HospitalId { get; set; }

        public string Name { get; set; }
        
        public string PhoneNumer { get; set; }

        public DateTime RegisterDate { get; set; }
        
        public CreatedUserDTO Admin { get; set; }

        public ServicesCatalogDTO ServicesCatalog { get; set; }

    }
}