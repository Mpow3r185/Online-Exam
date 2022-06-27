using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class TestimonialService : ITestimonialService
    {
        #region Fields
        private readonly ITestimonialRepository testimonialRepository;
        #endregion Fields

        #region Constructor
        public TestimonialService(ITestimonialRepository _testimonialRepository)
        {
            testimonialRepository = _testimonialRepository;
        }
        #endregion Constructor

        #region GetTestimonials
        public List<TestimonialDTO> GetTestimonials()
        {
            return testimonialRepository.GetTestimonials();
        }
        #endregion GetTestimonials

        #region CreateTestimonial
        public bool CreateTestimonial(Testimonial testimonial)
        {
            return testimonialRepository.CreateTestimonial(testimonial);
        }
        #endregion CreateTestimonial

        #region DeleteTestimonial
        public bool DeleteTestimonial(int id)
        {
            return testimonialRepository.DeleteTestimonial(id);
        }
        #endregion DeleteTestimonial

    }
}
