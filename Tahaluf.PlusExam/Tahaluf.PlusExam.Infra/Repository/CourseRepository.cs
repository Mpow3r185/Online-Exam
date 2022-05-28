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
        private readonly IDbContext dbContext;

        public CourseRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public bool CreateCourse(Course course)
        {
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

            dbContext.Connection.ExecuteAsync(
                "CoursePackage.CreateCourse", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }

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

        public List<Course> GetCourses()
        {
            return dbContext.Connection.Query<Course>(
                "CoursePackage.GetCourses",
                commandType : CommandType.StoredProcedure).ToList();
        }

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

        public bool UpdateCourse(Course course)
        {
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

            dbContext.Connection.ExecuteAsync(
                "CoursePackage.UpdateCourse", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
