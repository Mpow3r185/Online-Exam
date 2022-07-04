using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class ExamSubmitDTO
    {
        public List<UserResultsDTO> Results { get; set; }
        public int AccountId { get; set; }
        public int ExamId { get; set; }
    }
}
