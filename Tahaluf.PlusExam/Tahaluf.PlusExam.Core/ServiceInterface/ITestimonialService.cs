using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface ITestimonialService
    {
        // Get Testimonials
        List<Testimonial> GetTestimonials();


        // Create Testimonial
        bool CreateTestimonial(Testimonial testimonial);


        // Delete Testimonial
        bool DeleteTestimonial(int id);
    }
}
