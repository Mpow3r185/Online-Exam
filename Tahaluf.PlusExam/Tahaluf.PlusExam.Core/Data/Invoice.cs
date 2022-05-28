using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tahaluf.PlusExam.Core.Data
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatioDate { get; set; }

        public int? ExamId { get; set; }
        [ForeignKey("ExamId")]
       // public virtual Exam Exam{ get; set; }

        public int? AccountId { get; set; }
        [ForeignKey("AccountId")]
       // public virtual Account Account{ get; set; }

    }
}
