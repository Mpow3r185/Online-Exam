using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class ExamQuestionsDTO
    {
        public string Text { get; set; }
        public float Score { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public ChooseOptionDTO[] Options { get; set; }
        public FillOptionDTO FillOption { get; set; }
    }
}
