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
    public class QuestionOptionRepository : IQuestionOptionRepository
    {
        #region Fields
        private readonly IDbContext _dbContext;
        #endregion Fields

        #region Constructor
        public QuestionOptionRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateQuestionOption
        public bool CreateQuestionOption(QuestionOption questionOption)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("OContent", 
                questionOption.OptionContent,
                dbType: DbType.String, 
                direction: ParameterDirection.Input);

            parameters.Add("OQuestionId",
                questionOption.QuestionId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            _dbContext.Connection.ExecuteAsync(
                "QuestionOptionPackage.CreateQuestionOption", parameters,
                commandType: CommandType.StoredProcedure);
            
            return true;
        }
        #endregion CreateQuestionOption

        #region DeleteQuestionOption
        public bool DeleteQuestionOption(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Oid",
                id, 
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            _dbContext.Connection.ExecuteAsync(
                "QuestionOptionPackage.DeleteQuestionOption", parameters,
                commandType: CommandType.StoredProcedure);
            
            return true;
        }
        #endregion DeleteQuestionOption

        #region GetQuestionsOptions
        public List<QuestionOption> GetQuestionsOptions()
        {
            return _dbContext.Connection.Query<QuestionOption>(
                "QuestionOptionPackage.GetAllQuestionOption",
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion GetQuestionsOptions

        #region UpdateQuestionOption
        public bool UpdateQuestionOption(QuestionOption questionOption)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Oid",
                questionOption.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("OContent",
                questionOption.OptionContent,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("OQuestionId",
                questionOption.QuestionId, 
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            _dbContext.Connection.ExecuteAsync(
                "QuestionOptionPackage.UpdateQuestionOption", parameters,
                commandType: CommandType.StoredProcedure);
            
            return true;
        }
        #endregion UpdateQuestionOption

        #endregion CRUD_Operation
    }
}
