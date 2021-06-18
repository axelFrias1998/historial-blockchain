using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace historial_blockchain.Models
{
    public class PacientValidation
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public IFormFile File { get; set; }

        public string FileName => File?.FileName;
    }
}