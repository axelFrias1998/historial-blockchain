using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace historial_blockchain.Models
{
    public class PacientValidation
    {

        [JsonInclude]
        [Required(ErrorMessage = "El Username es un campo requerido")]
        public string Username { get; set; }

        [DataType(DataType.Password), Compare("Password")]
        [JsonInclude]
        [Required(ErrorMessage = "La confirmación de Password es un campo requerido")]
        public string Password { get; set; }

        [Display(Name = "File")]
        [Required(ErrorMessage = "Elige tu archivo")]
        public IFormFile File { get; set; }

        [FileExtensions(Extensions = "gti")]
        public string FileName => File?.FileName;
    }
}