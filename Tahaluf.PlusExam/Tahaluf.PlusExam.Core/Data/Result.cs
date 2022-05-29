using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tahaluf.PlusExam.Core.Data
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        public int? QuestionOptionId { get; set; }
        [ForeignKey("QuestionOptionId")]
        public virtual QuestionOption QuestionOption { get; set; }
        
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Accounts { get; set; }


    }
}
