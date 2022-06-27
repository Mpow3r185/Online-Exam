using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class ExamFilter
    {
        public string ExTitle { get; set; }
        public string ExLevelBeginner { get; set; }
        public string ExLevelIntermediate { get; set; }
        public string ExLevelAdvanced { get; set; }
        public string ExLevelExpert { get; set; }
        public decimal? SuccMark { get; set; }
        public decimal? Price { get; set; }
        public DateTime? StDate { get; set; }
        public DateTime? EnDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CName { get; set; }
    }
}
