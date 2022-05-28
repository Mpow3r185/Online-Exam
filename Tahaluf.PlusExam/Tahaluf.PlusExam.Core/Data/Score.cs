using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tahaluf.PlusExam.Core.Data
{
    public class Score
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Grade { get; set; }
        [Required]
        public string Status { get; set; }
        public int? ExamId { get; set; }
        //[ForeignKey("ExamId")]
        //public virtual Exam Exam { get; set; }
        [Required]
        public int AccountId { get; set; }
        //[ForeignKey("AccountId")]
        //public virtual Account Account { get; set; }

    }
}
