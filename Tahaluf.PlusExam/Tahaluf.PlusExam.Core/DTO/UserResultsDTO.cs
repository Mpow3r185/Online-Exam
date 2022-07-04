using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class UserResultsDTO
    {
        public int questionId { get; set; }
        public int? optionId { get; set; }
        public string fillResult { get; set; }
    }
}
