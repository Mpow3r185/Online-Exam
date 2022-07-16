using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class QuestionsDetailsDTO
    {
        public List<QuestionExamDTO> QuestionsExams { get; set; }
        public List<QuestionOption> QuestionsOptions { get; set; }
        public List<CorrectAnswer> CorrectAnswers { get; set; }
    }
}
