using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tahaluf.PlusExam.Core.Data
{
    public class CorrectAnswer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int QuestionOptionId { get; set; }
        [ForeignKey("QuestionOptionId")]
        public virtual QuestionOption QuestionOption { get; set; }
    }
}
