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

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Phone]
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [ForeignKey("ServicesCatalog")]
        [Required]
        public int ServiceCatalogId { get; set; }
        
        public virtual ServicesCatalog ServicesCatalog { get; set; }

        [ForeignKey("Admin")]
        [Required]
        public string AdminId { get; set; }

        public virtual ApplicationUser Admin { get; set; }
    }
}