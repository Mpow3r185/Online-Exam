using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.GenericInterface;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Infra.Generic;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class CourseRepository : ICourseRepository
    {
        #region Fields
        private readonly IGenericCRUD<Course> genericCRUD;
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public CourseRepository(IDbContext _dbContext)
        {
            genericCRUD = new GenericCRUD<Course>(_dbContext);
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateCourse
        public bool CreateCourse(Course course)
        {
            return genericCRUD.Create(course);
        }
        #endregion CreateCourse

        #region DeleteCourse
        public bool DeleteCourse(int cid)
        {
            return genericCRUD.Delete(cid);
        }
        #endregion DeleteCourse

        #region GetCourses
        public List<Course> GetCourses()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetCourses

        #region UpdateCourse
        public bool UpdateCourse(Course course)
        {
            return genericCRUD.Update(course);
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

        public List<PopularCoursesDTO> GetPopularCourses()
        {
            return this.dbContext.Connection.Query<PopularCoursesDTO>(
                "CoursePackage.GetPopularCourses",
                commandType: CommandType.StoredProcedure).ToList();
        }
        
        public Course GetCourseById(int cid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cid",
                cid,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            return this.dbContext.Connection.Query<Course>(
                "CoursePackage.GetCourseById", parameters,
                commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
