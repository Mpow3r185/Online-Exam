using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tahaluf.PlusExam.Core.Data
{
    public class QuestionOption
    {
        [Key]
        public int Id { get; set; }
        public string OptionContent { get; set; }

        public int? QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        public ICollection<Result> results { get; set; }
        //public ICollection<CorrectAnswer> correctAnswer { get; set; }
    }
}
