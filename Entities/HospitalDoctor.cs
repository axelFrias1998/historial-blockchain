using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using historial_blockchain.Models;

namespace historial_blockchain.Entities
{
    public class HospitalDoctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string DoctorId { get; set; }

        public string HospitalId { get; set; }

        [ForeignKey("Especialidad")]
        public int EspecialidadId { get; set; }

        public virtual SpecialitiesCatalog Especialidad { get; set;}

        public virtual Hospital Hospital { get; set; }

        public virtual ApplicationUser Doctor { get; set; }
    }
}

//Load all the Books with their Tags
//var books = context.Books.Include(b => b.Tags).ToList()
//Get all the books with the TagId (which holds the category name)
//var books = context.Books.Tags.Select(t => t.TagId).ToList()