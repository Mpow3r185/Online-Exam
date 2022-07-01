using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class QuestionContentDTO
    {
        public Question Question { get; set; }
        public List<QuestionOption> Options { get; set; }
    }
}
