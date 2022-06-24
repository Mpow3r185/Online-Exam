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
        #region Fields
        private readonly ICourseRepository courseRepository;
        #endregion Fields

        #region Constructor
        public CourseService(ICourseRepository _courseRepository)
        {
            courseRepository = _courseRepository;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateCourse
        public bool CreateCourse(Course course)
        {
            return courseRepository.CreateCourse(course);
        }
        #endregion CreateCourse

        #region DeleteCourse
        public bool DeleteCourse(int cid)
        {
            return courseRepository.DeleteCourse(cid);
        }
        #endregion DeleteCourse

        #region GetCourses
        public List<Course> GetCourses()
        {
            return courseRepository.GetCourses();
        }
        #endregion GetCourses

        #region UpdateCourse
        public bool UpdateCourse(Course course)
        {
            return courseRepository.UpdateCourse(course);
        }
        #endregion UpdateCourse

        #endregion CRUD_Operation

        public List<Course> SearchCourse(CourseFilter courseFilter)
        {
            return courseRepository.SearchCourse(courseFilter);
        }

        public List<string> GetCoursesNames()
        {
            return courseRepository.GetCoursesNames();
        }

        public List<PopularCoursesDTO> GetPopularCourses()
        {
            return courseRepository.GetPopularCourses();
        }

        public Course GetCourseById(int cid)
        {
            return this.courseRepository.GetCourseById(cid);
        }
    }
}
