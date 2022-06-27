using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.PlusExam.Core.DTO
{
    public class TestimonialDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string UserName { get; set; }   
        public string FullName { get; set; }   

        public string Message { get; set; }
        public string ProfilePicture { get; set; }
        public string Status { get; set; }
    }
}
