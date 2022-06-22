﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
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
        [HttpPost]
        [Route("SearchCourse")]
        public List<Course> SearchCourse(CourseFilter courseFilter)
        {
            return courseService.SearchCourse(courseFilter);
        }
        #endregion SearchCourse
        
        #region UploadImage
        [HttpPost]
        [Route("Upload")]
        public Course UploadImage()
        {
            try
            {
                var image = Request.Form.Files[0];
                var imageName = Guid.NewGuid() + "_" + image.FileName;
                var fullPath = Path.Combine("Image", imageName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                Course course = new Course();
                course.CourseImage = imageName;
                return course;

            }

            catch (Exception)
            {
                return null;
            }
        }
        #endregion UploadImage
        
    }
}
