using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;

namespace Tahaluf.PlusExam.Core.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required, NotNull, MaxLength(30)]
        public string CourseName { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [MaxLength(7)]
        public string Status { get; set; }

        [MaxLength(255)]
        public string CourseImage { get; set; }


        public ICollection<Exam> Exams { get; set; }
    }
}
