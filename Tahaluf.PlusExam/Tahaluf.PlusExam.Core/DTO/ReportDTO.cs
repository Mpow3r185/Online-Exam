using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class ReportDTO
    {
        public int AccId { get; set; }
        public string CourseName { get; set; }
        public string Title { get; set; }
        public float Cost { get; set; }
        public string ExamLevel { get; set; }
        public DateTime CreatioDate { get; set; }   
        public float Grade { get; set; } 
        public string FullName { get; set; }
    }
}
