using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tahaluf.PlusExam.Core.Data
{
    public class ZoomMeeting
    {
        [Key]
        public int Id { get; set; }

        public string ZoomLink { get; set; }

        public int ExamId { get; set; }
    }
}
