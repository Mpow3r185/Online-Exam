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
    public class ExamRepository : IExamRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public ExamRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateExam
        public bool CreateExam(Exam exam)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cid",
                exam.CourseId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("exTitle",
                exam.Title,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("passc",
                exam.Passcode,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("des",
                exam.Description,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("exLevel",
                exam.ExamLevel,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("succMark",
                exam.SuccessMark,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            parameters.Add("price",
                exam.Cost,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            parameters.Add("stDate",
                exam.StartDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            parameters.Add("enDate",
                exam.EndDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            parameters.Add("st",
                exam.Status,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("createDate",
                exam.CreationDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            dbContext.Connection.ExecuteAsync(
                "ExamPackage.CreateExam", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion CreateExam

        #region DeleteExam
        public bool DeleteExam(int exid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("exid",
                exid,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            dbContext.Connection.ExecuteAsync(
                "ExamPackage.DeleteExam", parameters,
                commandType : CommandType.StoredProcedure);

            return true;
        }
        #endregion DeleteExam

        #region GetExams
        public List<Exam> GetExams()
        {
            return dbContext.Connection.Query<Exam>(
                "ExamPackage.GetExams",
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion GetExams

        #region UpdateExam
        public bool UpdateExam(Exam exam)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("exid",
                exam.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("cid",
                exam.CourseId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("exTitle",
                exam.Title,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("passc",
                exam.Passcode,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("des",
                exam.Description,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("exLevel",
                exam.ExamLevel,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("succMark",
                exam.SuccessMark,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            parameters.Add("price",
                exam.Cost,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            parameters.Add("stDate",
                exam.StartDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            parameters.Add("enDate",
                exam.EndDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            parameters.Add("st",
                exam.Status,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("createDate",
                exam.CreationDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            dbContext.Connection.ExecuteAsync(
                "ExamPackage.UpdateExam", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
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

            parameters.Add("exLevel",
                examFilter.ExLevel,
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
            #endregion DynamicParameters

            return dbContext.Connection.Query<Exam>(
                "ExamPackage.SearchExam", parameters,
                commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
