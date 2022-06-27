using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface ITestimonialService
    {
        // Get Testimonials
        List<TestimonialDTO> GetTestimonials();


        // Create Testimonial
        bool CreateTestimonial(Testimonial testimonial);


        // Delete Testimonial
        bool DeleteTestimonial(int id);
    }
}
