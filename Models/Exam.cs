using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eproject.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Subject { get; set; }

        [Required]
        public DateTime ExamDate { get; set; }

        [Required]
        public int DurationMinutes { get; set; }

        [Required]
        public int TotalMarks { get; set; }
    }
}

