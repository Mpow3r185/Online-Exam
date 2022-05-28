using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;

namespace Tahaluf.PlusExam.Core.Data
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }

        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        
        [Required, NotNull, MaxLength(50)]
        public string Title { get; set; }

        [Required, NotNull, MaxLength(8)]
        public string Passcode { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required, NotNull, MaxLength(12)]
        public string ExamLevel { get; set; }
        
        public decimal SuccessMark { get; set; }

        public decimal Cost { get; set; }

        [Required, NotNull]
        public DateTime StartDate { get; set; }

        [Required, NotNull]
        public DateTime EndDate { get; set; }

        [MaxLength(7)]
        public string Status { get; set; }

        public DateTime CreationDate { get; set; }


        public virtual Course Course { get; set; }


        public ICollection<Question> Questions { get; set; }
        //public ICollection<Invoice> Invoices { get; set; }
        //public ICollection<Certificate> Certificates { get; set; }
        //public ICollection<Score> Scores { get; set; }
    }
}
