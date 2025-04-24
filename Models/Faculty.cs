using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eproject.Areas.Identity.Data;

namespace Eproject.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        [Required]

        public string? Fname { get; set; }
        public string Timing { get; set; }

        public string? Education { get; set; }
        public string? Skills { get; set; }

    }
}
