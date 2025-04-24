using Eproject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    [Key]
    public int StudentId { get; set; }

    [Required]
    public string StudentName { get; set; }

    public string Course { get; set; }

    public string BatchId { get; set; }


}


