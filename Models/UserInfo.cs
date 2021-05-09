using System.ComponentModel.DataAnnotations;

namespace historial_blockchain.Models
{
    public class UserInfo
    {
        [DataType(DataType.Text)]        
        [Required(ErrorMessage = "Apellido es requerido")]
        [StringLength(100)]
        public string Apellido { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password confirmation is required")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]        
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
    }
}