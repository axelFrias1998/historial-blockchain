using System;
using historial_blockchain.Models;

namespace historial_blockchain.Entities
{
    public class Hospital
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisterDate { get; set; }

        public int ServiceCatalogId { get; set; }
        
        public ServicesCatalog ServicesCatalog { get; set; }

        public string AdminId { get; set; }
  
        public ApplicationUser Admin { get; set; }
    }
}