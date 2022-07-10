using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class CertificateDTO
    {
        public DateTime creationDate { get; set; }
        public string examName { get; set; }
        public string examLevel { get; set; }
        public DateTime examDate { get; set; }
    }
}
