using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Tahaluf.PlusExam.Core.Data
{
    public class Testimonial
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }

        [MaxLength(8)]
        public string Status { get; set; }
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

    }
}
