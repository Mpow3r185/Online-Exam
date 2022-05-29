using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        #region Fields
        private readonly ICourseService courseService;
        #endregion Fields

        #region Constructor
        public CourseController(ICourseService _courseService)
        {
            courseService = _courseService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateCourse
        [HttpPost]
        public bool CreateCourse(Course course)
        {
            return courseService.CreateCourse(course);
        }
        #endregion CreateCourse

        #region DeleteCourse
        [HttpDelete]
        [Route("DeleteCourse/{cid}")]
        public bool DeleteCourse(int cid)
        {
            return courseService.DeleteCourse(cid);
        }
        #endregion DeleteCourse

        #region GetCourses
        [HttpGet]
        public List<Course> GetCourses()
        {
            return courseService.GetCourses();
        }
        #endregion GetCourses

        #region UpdateCourse
        [HttpPut]
        public bool UpdateCourse(Course course)
        {
            return courseService.UpdateCourse(course);
        }
        #endregion UpdateCourse

        #endregion CRUD_Operation

        #region GetCoursesNames
        [HttpGet]
        [Route("GetCoursesNames")]
        public List<string> GetCoursesNames()
        {
            return courseService.GetCoursesNames();
        }
        #endregion GetCoursesNames

        #region SearchCourse
        [HttpGet]
        [Route("SearchCourse")]
        public List<Course> SearchCourse(CourseFilter courseFilter)
        {
            return courseService.SearchCourse(courseFilter);
        }
        #endregion SearchCourse
    }
}
