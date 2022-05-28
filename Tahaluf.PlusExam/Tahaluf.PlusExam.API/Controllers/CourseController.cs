using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService _courseService)
        {
            courseService = _courseService;
        }

        [HttpPost]
        public bool CreateCourse(Course course)
        {
            return courseService.CreateCourse(course);
        }

        [HttpDelete]
        [Route("DeleteCourse/{cid}")]
        public bool DeleteCourse(int cid)
        {
            return courseService.DeleteCourse(cid);
        }

        [HttpGet]
        public List<Course> GetCourses()
        {
            return courseService.GetCourses();
        }

        [HttpGet]
        [Route("GetCoursesNames")]
        public List<string> GetCoursesNames()
        {
            return courseService.GetCoursesNames();
        }

        [HttpGet]
        [Route("SearchCourse")]
        public List<Course> SearchCourse(CourseFilter courseFilter)
        {
            return courseService.SearchCourse(courseFilter);
        }

        [HttpPut]
        public bool UpdateCourse(Course course)
        {
            return courseService.UpdateCourse(course);
        }

    }
}
