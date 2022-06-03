using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tahaluf.PlusExam.Core.Data
{
    public class FillResult
    {
        [Key]
        public int Id { get; set; }

        public string Answer { get; set; }

        public int QuestionId { get; set; }
        [ForeignKey("QuestionIdId")]
        public virtual Question Question { get; set; }

        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}
