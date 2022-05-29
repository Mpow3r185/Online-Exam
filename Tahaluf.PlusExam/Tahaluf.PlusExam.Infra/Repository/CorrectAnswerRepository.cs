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
    public class CorrectAnswerRepository : ICorrectAnswerRepository
    {
        #region Fields
        private readonly IDbContext _dbContext;
        #endregion Fields

        #region Constructor
        public CorrectAnswerRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetCorrectAnswers
        // Get Correct Answers
        public List<CorrectAnswer> GetCorrectAnswers()
        {
            return _dbContext.Connection.Query<CorrectAnswer>(
                "CorrectAnswerPackage.GetAll",
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion GetCorrectAnswers

        #region CreateCorrectAnswer
        // Create CorrectAnswer
        public bool CreateCorrectAnswer(CorrectAnswer correctAnswer)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("QOID", 
                correctAnswer.QuestionOptionId, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            _dbContext.Connection.ExecuteAsync(
                "CorrectAnswerPackage.CreateCorrectAnswer", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion CreateCorrectAnswer

        #region UpdateCorrectAnswer
        // Update CorrectAnswer
        public bool UpdateCorrectAnswer(CorrectAnswer correctAnswer)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("CANSWERID", 
                correctAnswer.Id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            parameters.Add("QOID", 
                correctAnswer.QuestionOptionId, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            _dbContext.Connection.ExecuteAsync(
                "CorrectAnswerPackage.UpdateCorrectAnswer", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion UpdateCorrectAnswer

        #region DeleteCorrectAnswer
        // Delete CorrectAnswer
        public bool DeleteCorrectAnswer(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("CANSWERID",
                id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            _dbContext.Connection.ExecuteAsync(
                "CorrectAnswerPackage.DeleteCorrectAnswer", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion DeleteCorrectAnswer

        #endregion CRUD_Operation
    }
}
