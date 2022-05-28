using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository _courseRepository)
        {
            courseRepository = _courseRepository;
        }

        public bool CreateCourse(Course course)
        {
            return courseRepository.CreateCourse(course);
        }

        public bool DeleteCourse(int cid)
        {
            return courseRepository.DeleteCourse(cid);
        }

        public List<Course> GetCourses()
        {
            return courseRepository.GetCourses();
        }

        public List<string> GetCoursesNames()
        {
            return courseRepository.GetCoursesNames();
        }

        public List<Course> SearchCourse(CourseFilter courseFilter)
        {
            return courseRepository.SearchCourse(courseFilter);
        }

        public bool UpdateCourse(Course course)
        {
            return courseRepository.UpdateCourse(course);
        }
    }
}
