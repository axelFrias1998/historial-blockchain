using historial_blockchain.Entities;
using Microsoft.AspNetCore.Identity;

namespace historial_blockchain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Hospital Hospital { get; set; }
    }
}