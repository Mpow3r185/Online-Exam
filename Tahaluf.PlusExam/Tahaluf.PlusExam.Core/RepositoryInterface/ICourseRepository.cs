using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface ICourseRepository
    {
        // Get Courses
        List<Course> GetCourses();

        // Create Course
        bool CreateCourse(Course course);

        // Update Course
        bool UpdateCourse(Course course);

        // Delete Course
        bool DeleteCourse(int cid);

        // Get Courses Names
        List<string> GetCoursesNames();

        // Search Course
        List<Course> SearchCourse(CourseFilter courseFilter);

        // Get Popular Courses
        List<PopularCoursesDTO> GetPopularCourses();

        // Get Course By Id
        Course GetCourseById(int cid);
    }
}
