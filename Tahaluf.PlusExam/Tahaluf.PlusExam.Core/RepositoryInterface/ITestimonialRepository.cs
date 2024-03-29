﻿using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;


namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface ITestimonialRepository
    {
        // Get Testimonials
        List<TestimonialDTO> GetTestimonials();


        // Create Testimonial
        bool CreateTestimonial(Testimonial testimonial);


        // Delete Testimonial
        bool DeleteTestimonial(int id);

        // Update Testimonial
        bool UpdateTestimonial(Testimonial testimonial);
    }
}
