using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.GenericInterface;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Infra.Generic;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        private readonly IGenericCRUD<Testimonial> genericCRUD;
        #endregion Fields

        #region Constructor
        public TestimonialRepository(IDbContext _dbContext)
        {
            genericCRUD = new GenericCRUD<Testimonial>(_dbContext);
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region GetTestimonials
        public List<TestimonialDTO> GetTestimonials()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetTestimonials

        #region CreateTestimonial
        public bool CreateTestimonial(Testimonial testimonial)
        {
            return genericCRUD.Create(testimonial);
        }
        #endregion CreateTestimonial

        #region DeleteTestimonial
        public bool DeleteTestimonial(int id)
        {
            return genericCRUD.Delete(id);
        }
        #endregion DeleteTestimonial

        public bool UpdateTestimonial(Testimonial testimonial)
        {
            return genericCRUD.Update(testimonial);
        }

    }
}
