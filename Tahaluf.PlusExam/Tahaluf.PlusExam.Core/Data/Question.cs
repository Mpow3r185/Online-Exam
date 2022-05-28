using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tahaluf.PlusExam.Core.Data
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public string Type { get; set; }
        public float? Score { get; set; }
        public string Status { get; set; }
        
        public int? ExamId { get; set; }
        [ForeignKey("ExamId")]
        public virtual Exam Exam { get; set; }

        public ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
