using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class EmailDTO
    {
        public int studentId { get; set; }
        public string SendTo { get; set; }
        public string SendFrom { get; set; }
        public string emailPassword { get; set; }
        public string examPassword { get; set; }
    }
}
