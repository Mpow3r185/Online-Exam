using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class InvoiceDTO
    {
        public DateTime creationDate { get; set; }
        public string examName { get; set; }
        public string examLevel { get; set; }
        public decimal examCost { get; set; }
    }
}
