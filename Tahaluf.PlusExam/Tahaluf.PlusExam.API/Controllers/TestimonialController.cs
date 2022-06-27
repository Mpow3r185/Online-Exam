using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        #region Fields
        private readonly ITestimonialService testimonialService;
        #endregion Fields

        #region Constructor
        public TestimonialController(ITestimonialService _testimonialService)
        {
            testimonialService = _testimonialService;
        }
        #endregion Constructor

        #region CreateTestimonial
        [HttpPost]
        public bool CreateTestimonial(Testimonial testimonial)
        {
            return testimonialService.CreateTestimonial(testimonial);
        }
        #endregion CreateTestimonial

        #region DeleteTestimonial
        [HttpDelete]
        [Route("deleteTestimonial/{id}")]
        public bool DeleteTestimonial(int id)
        {
            return testimonialService.DeleteTestimonial(id);
        }
        #endregion DeleteTestimonial

        #region GetTestimonials
        [HttpGet]
        public List<TestimonialDTO> GetTestimonials()
        {
            return testimonialService.GetTestimonials();
        }
        #endregion GetTestimonials
    }
}
