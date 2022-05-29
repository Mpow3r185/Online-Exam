using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class ExamFilter
    {
        public string ExTitle { get; set; }
        public string ExLevel { get; set; }
        public decimal? SuccMark { get; set; }
        public decimal? Price { get; set; }
        public DateTime? StDate { get; set; }
        public DateTime? EnDate { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
