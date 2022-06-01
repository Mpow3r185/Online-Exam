using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tahaluf.PlusExam.Core.Data
{
    public class HomePage
    {
        [Key]
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string SiteEmail { get; set; }
        public string SitePhoneNumber { get; set; }
    }
}
