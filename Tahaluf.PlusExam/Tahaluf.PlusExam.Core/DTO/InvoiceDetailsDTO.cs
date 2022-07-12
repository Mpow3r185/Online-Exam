using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class InvoiceDetailsDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ExamName { get; set; }
        public float examCost { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
