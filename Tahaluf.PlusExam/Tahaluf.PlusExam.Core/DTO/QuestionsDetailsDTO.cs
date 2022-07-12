using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class QuestionsDetailsDTO
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string QuestionContent { get; set; }

        public string Type { get; set; }
        public decimal Score { get; set; }
        public string Status { get; set; }
        public string OptionContent{ get; set; }
        public int QuestionOptionId { get; set; }
    }
}
