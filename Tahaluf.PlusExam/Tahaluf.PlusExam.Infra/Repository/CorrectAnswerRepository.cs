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
        private readonly IDbContext _dbContext;
        public CorrectAnswerRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        // Get All Correct Answers
        public List<CorrectAnswer> GetAll()
        {
            IEnumerable<CorrectAnswer> result = _dbContext.Connection.Query<CorrectAnswer>("CorrectAnswerPackage.GetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        // Create
        public bool CreateCorrectAnswer(CorrectAnswer correctAnswer)
        {
            var p = new DynamicParameters();
            p.Add("QOID", correctAnswer.QuestionOptionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("CorrectAnswerPackage.CreateCorrectAnswer", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        //Update
        public bool UpdateCorrectAnswer(CorrectAnswer correctAnswer)
        {
            var p = new DynamicParameters();
            p.Add("CANSWERID", correctAnswer.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("QOID", correctAnswer.QuestionOptionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("CorrectAnswerPackage.UpdateCorrectAnswer", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        //Delete
        public bool DeleteCorrectAnswer(int id)
        {
            var p = new DynamicParameters();
            p.Add("CANSWERID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("CorrectAnswerPackage.DeleteCorrectAnswer", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        

    }
}
