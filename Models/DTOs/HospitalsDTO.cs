using System;
using System.Collections.Generic;
using historial_blockchain.Entities;

namespace historial_blockchain.Models.DTOs
{
    public class HospitalsDTO
    {
        public string HospitalId { get; set; }

        public string Name { get; set; }
        
        public string PhoneNumber { get; set; }

        public DateTime RegisterDate { get; set; }
        
        public List<CreatedUserDTO> Admins { get; set; }

        public List<SpecialitiesDTO> Especialidades { get; set; }

        public ServicesCatalog ServicesCatalog { get; set; }

    }
}