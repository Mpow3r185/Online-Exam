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
    public class ResultRepository : IResultRepository
    {
        #region Fields
        private readonly IDbContext _dbContext;
        #endregion Fields

        #region Constructor
        public ResultRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateResult
        public bool CreateResult(Result result)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("RQuestionOptionId",
                result.QuestionOptionId, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            parameters.Add("RAccountId",
                result.AccountId, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            _dbContext.Connection.ExecuteAsync(
                "ResultPackage.CreateResult", parameters,
                commandType: CommandType.StoredProcedure);
            
            return true;
        }
        #endregion CreateResult

        #region DeleteResult
        public bool DeleteResult(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Rid",
                id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            _dbContext.Connection.ExecuteAsync(
                "ResultPackage.DeleteResult", parameters,
                commandType: CommandType.StoredProcedure);
            
            return true;
        }
        #endregion DeleteResult

        #region GetResults
        public List<Result> GetResults()
        {
            return _dbContext.Connection.Query<Result>(
                "ResultPackage.GetAllResult", 
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion GetResults

        #region UpdateResult
        public bool UpdateResult(Result result)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Rid",
                result.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("RQuestionOptionId",
                result.QuestionOptionId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("RAccountId",
                result.AccountId, 
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            _dbContext.Connection.ExecuteAsync(
                "ResultPackage.UpdateResult", parameters,
                commandType: CommandType.StoredProcedure);
            
            return true;
        }
        #endregion UpdateResult

        #endregion CRUD_Operation
    }
}
