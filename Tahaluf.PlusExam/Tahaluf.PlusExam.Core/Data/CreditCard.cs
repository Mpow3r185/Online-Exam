using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tahaluf.PlusExam.Core.Data
{
    public class CreditCard
    {
        [Key]
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public float Balance { get; set; }

        public int? AccountId { get; set; }
        [ForeignKey("AccountId")]
         public virtual Account Account{ get; set; }

    }
}
