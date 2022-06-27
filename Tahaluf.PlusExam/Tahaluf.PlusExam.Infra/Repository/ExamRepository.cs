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
    public class ExamRepository : IExamRepository
    {
        #region Fields
        private readonly IGenericCRUD<Exam> genericCRUD;
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public ExamRepository(IDbContext _dbContext)
        {
            genericCRUD = new GenericCRUD<Exam>(_dbContext);
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateExam
        public bool CreateExam(Exam exam)
        {
            return genericCRUD.Create(exam);
        }
        #endregion CreateExam

        #region DeleteExam
        public bool DeleteExam(int exid)
        {
            return genericCRUD.Delete(exid);
        }
        #endregion DeleteExam

        #region GetExams
        public List<Exam> GetExams()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetExams

        #region UpdateExam
        public bool UpdateExam(Exam exam)
        {
            return genericCRUD.Update(exam);
        }
        #endregion UpdateExam

        #endregion CRUD_Operation

        public List<Exam> SearchExam(ExamFilter examFilter)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("exTitle",
                examFilter.ExTitle,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("ExLevelBeginner",
                examFilter.ExLevelBeginner,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("ExLevelIntermediate",
                examFilter.ExLevelIntermediate,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("ExLevelAdvanced",
                examFilter.ExLevelAdvanced,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("ExLevelExpert",
                examFilter.ExLevelExpert,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("succMark",
                examFilter.SuccMark,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            parameters.Add("price",
                examFilter.Price,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            parameters.Add("stDate",
                examFilter.StDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            parameters.Add("enDate",
                examFilter.EnDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            parameters.Add("createDate",
                examFilter.CreateDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            parameters.Add("cName",
                examFilter.CName,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return dbContext.Connection.Query<Exam>(
                "ExamPackage.SearchExam", parameters,
                commandType: CommandType.StoredProcedure).ToList();
        }

        public List<Exam> GetExamsByCourseId(int cid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cid",
                cid,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            return dbContext.Connection.Query<Exam>(
                "ExamPackage.GetExamsByCourseId", parameters,
                commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
