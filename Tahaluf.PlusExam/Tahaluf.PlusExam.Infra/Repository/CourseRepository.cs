using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class CourseRepository : ICourseRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public CourseRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateCourse
        public bool CreateCourse(Course course)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cName",
                course.CourseName,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("des",
                course.Description,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("st",
                course.Status,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("cImage",
                course.CourseImage,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            dbContext.Connection.ExecuteAsync(
                "CoursePackage.CreateCourse", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion CreateCourse

        #region DeleteCourse
        public bool DeleteCourse(int cid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cid",
                cid,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            dbContext.Connection.ExecuteAsync(
                "CoursePackage.DeleteCourse", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion DeleteCourse

        #region GetCourses
        public List<Course> GetCourses()
        {
            return dbContext.Connection.Query<Course>(
                "CoursePackage.GetCourses",
                commandType : CommandType.StoredProcedure).ToList();
        }
        #endregion GetCourses

        #region UpdateCourse
        public bool UpdateCourse(Course course)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cid",
                course.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("cName",
                course.CourseName,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("des",
                course.Description,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("st",
                course.Status,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("cImage",
                course.CourseImage,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            dbContext.Connection.ExecuteAsync(
                "CoursePackage.UpdateCourse", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion UpdateCourse

        #endregion CRUD_Operation

        public List<string> GetCoursesNames()
        {
            return dbContext.Connection.Query<string>(
                "CoursePackage.GetCoursesNames",
                commandType: CommandType.StoredProcedure).ToList();
        }

        public List<Course> SearchCourse(CourseFilter courseFilter)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cid",
                courseFilter.Cid,
                dbType : DbType.Int32,
                direction : ParameterDirection.Input);

            parameters.Add("cName",
                courseFilter.CName,
                dbType : DbType.String,
                direction : ParameterDirection.Input);

            return dbContext.Connection.Query<Course>(
                "CoursePackage.SearchCourse", parameters,
                commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
