using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class FillResultRepository : IFillResultRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public FillResultRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetFillResults
        public List<FillResult> GetFillResults()
        {
            return dbContext.Connection.Query<FillResult>(
                "FillResultPackage.GetFillResults",
                commandType: CommandType.StoredProcedure).ToList();
        }

        #endregion GetFillResults

        #region CreateFillResult
        public bool CreateFillResult(FillResult fillResult)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ans",
                fillResult.Answer,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("qid",
                fillResult.QuestionId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("accid",
                fillResult.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            dbContext.Connection.ExecuteAsync(
                "FillResultPackage.CreateFillResult", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion CreateFillResult

        #region UpdateFillResult
        public bool UpdateFillResult(FillResult fillResult)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("frid",
                fillResult.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            
            parameters.Add("ans",
                fillResult.Answer,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("qid",
                fillResult.QuestionId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("accid",
                fillResult.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            dbContext.Connection.ExecuteAsync(
                "FillResultPackage.UpdateFillResult", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion UpdateFillResult

        #region DeleteFillResult
        public bool DeleteFillResult(int frid)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("frid",
                frid,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            dbContext.Connection.ExecuteAsync(
                "FillResultPackage.DeleteFillResult", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion DeleteFillResult

        #endregion CRUD_Operation

        public string GetAnswerByQuestionIdAndAccountId(FillResult fillResult)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("qid",
                fillResult.QuestionId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("accid",
                fillResult.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return dbContext.Connection.Query<string>(
                "FillResultPackage.GetAnswerByQuestionIdAndAccountId",
                parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public List<FillResult> GetFillResultByQuestionId(int qid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("qid",
                qid,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            return dbContext.Connection.Query<FillResult>(
                "FillResultPackage.GetFillResultByQuestionId",
                parameters, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
