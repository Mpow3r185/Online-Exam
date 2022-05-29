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
    public class QuestionRepository : IQuestionRepository
    {
        #region Fields
        private readonly IDbContext _dbContext;
        #endregion Fields

        #region Constructor
        public QuestionRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateQuestion
        public bool CreateQuestion(Question question)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("QContent",
                question.QuestionContent,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("QType",
                question.Type, 
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("QScore",
                question.Score,
                dbType: DbType.Double,
                direction: ParameterDirection.Input);

            parameters.Add("QStatues",
                question.Status, 
                dbType: DbType.String, 
                direction: ParameterDirection.Input);

            parameters.Add("QExamId",
                question.ExamId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            _dbContext.Connection.ExecuteAsync(
                "QuestionPackage.CreateQuestion", parameters, 
                commandType: CommandType.StoredProcedure);
            
            return true;
        }
        #endregion CreateQuestion

        #region DeleteQuestion
        public bool DeleteQuestion(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Qid",
                id, 
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
           
            _dbContext.Connection.ExecuteAsync(
                "QuestionPackage.DeleteQuestion", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion DeleteQuestion

        #region GetQuestions
        public List<Question> GetQuestions()
        {
            return _dbContext.Connection.Query<Question>(
                "QuestionPackage.GetAllQuestion",
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion GetQuestions

        #region UpdateQuestion
        public bool UpdateQuestion(Question question)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Qid", 
                question.Id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            parameters.Add("QContent",
                question.QuestionContent,
                dbType: DbType.String, 
                direction: ParameterDirection.Input);

            parameters.Add("QType", 
                question.Type, 
                dbType: DbType.String, 
                direction: ParameterDirection.Input);

            parameters.Add("QScore", 
                question.Score, 
                dbType: DbType.Double,
                direction: ParameterDirection.Input);

            parameters.Add("QStatues", 
                question.Status, 
                dbType: DbType.String, 
                direction: ParameterDirection.Input);

            parameters.Add("QExamId",
                question.ExamId, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            _dbContext.Connection.ExecuteAsync(
                "QuestionPackage.UpdateQuestion", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion UpdateQuestion

        #endregion CRUD_Operation
    }
}
