using System.ComponentModel.DataAnnotations.Schema;
using historial_blockchain.Entities;
using Microsoft.AspNetCore.Identity;

namespace historial_blockchain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Hospital")]
        public string HospitalId { get; set; }

        public virtual Hospital Hospital { get; set; }
    }
}