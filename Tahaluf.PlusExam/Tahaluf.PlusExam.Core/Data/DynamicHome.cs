using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Tahaluf.PlusExam.Core.Data
{
    public class DynamicHome
    {
     
        [Required, NotNull]
        public string webSiteName { get; set; }
        [MaxLength(255), NotNull]
        public string logoDark { get; set; }
        [MaxLength(1000), NotNull]
        public string logoLight { get; set; }
        [MaxLength(1000), NotNull]
        public string imgSlider1 { get; set; }
        [MaxLength(1000), NotNull]
        public string imgSlider2 { get; set; }
        [MaxLength(1000), NotNull]
        public string imgSlider3 { get; set; }
        [NotNull]
        public string title1 { get; set; }
        [NotNull]
        public string subTitle1 { get; set; }
        [NotNull]
        public string title2 { get; set; }
        [NotNull]
        public string subTitle2 { get; set; }
        [NotNull]
        public string popularParagraph { get; set; }
        [NotNull]
        public string footerParagraph { get; set; }
        [MaxLength(1000), NotNull]
        public string footerBackground { get; set; }
        [MaxLength(1000), NotNull]
        public string aboutBackground { get; set; }
        [NotNull]
        public string aboutParagraph { get; set; }
        [Required, NotNull]
        public string phoneNumber { get; set; }
        [Required, NotNull]
        public string email { get; set; }
        [NotNull]
        public string address { get; set; }
        [NotNull]
        public string contactParagraph { get; set; }
        [MaxLength(1000),NotNull]
        public string contactImage { get; set; }
        [MaxLength(1000), NotNull]
        public string headerBackgroud { get; set; }
        [MaxLength(1000), NotNull]
        public string faviconIcon { get; set; }







    }
}
