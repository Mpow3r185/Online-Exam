using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class QuestionExamDTO
    {
        public int ExamId { get; set; }
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public string Title { get; set; }
        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public string Type { get; set; }
        public float? Score { get; set; }
        public string Status { get; set; }
    }
}
