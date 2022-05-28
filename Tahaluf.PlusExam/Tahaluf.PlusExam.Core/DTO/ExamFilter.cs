using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class ExamFilter
    {
        public int? Exid { get; set; }
        public int? Cid { get; set; }
        public string ExTitle { get; set; }
        public string Passc { get; set; }
        public string Description{ get; set; }
        public ExamLevels? ExLevel { get; set; }
        public decimal? SuccMark { get; set; }
        public decimal? Price { get; set; }
        public DateTime? StDate { get; set; }
        public DateTime? EnDate { get; set; }
        public StatusOptions? St { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
