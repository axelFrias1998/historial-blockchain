using System.ComponentModel.DataAnnotations;

namespace historial_blockchain.Models
{
    public class UserLogin
    {
        
        [StringLength(256)]
        [Required(ErrorMessage = "Username is required")]
        
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}