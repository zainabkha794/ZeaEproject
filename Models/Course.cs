using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;



namespace changes_project.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]

        public string CourseName { get; set; }


        [Required]

        [DataType(DataType.Currency)]
        public decimal CourseFees { get; set; }

    }
}
