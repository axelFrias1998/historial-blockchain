using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using historial_blockchain.Models;
using Microsoft.AspNetCore.Identity;

namespace historial_blockchain.Entities
{
    public class Hospital
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisterDate { get; set; }

        [ForeignKey("ServicesCatalog")]
        public int ServiceCatalogId { get; set; }
        
        public virtual ServicesCatalog ServicesCatalog { get; set; }

        [ForeignKey("Admin")]
        public string AdminId { get; set; }

        public virtual ApplicationUser Admin { get; set; }
    }
}