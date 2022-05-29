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
        private readonly IDbContext _dbContext;
        public QuestionRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public bool CreateQuestion(Question question)
        {
            var p = new DynamicParameters();
            p.Add("QContent", question.QuestionContent, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("QType", question.Type, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("QScore", question.Score, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("QStatues", question.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("QExamId", question.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.ExecuteAsync("QuestionPackage.CreateQuestion", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteQuestion(int id)
        {
            var p = new DynamicParameters();
            p.Add("Qid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
           
            var result = _dbContext.Connection.ExecuteAsync("QuestionPackage.DeleteQuestion", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Question> Questions()
        {
            IEnumerable<Question> result = _dbContext.Connection.Query<Question>("QuestionPackage.GetAllQuestion", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateQuestion(Question question)
        {
            var p = new DynamicParameters();
            p.Add("Qid", question.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("QContent", question.QuestionContent, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("QType", question.Type, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("QScore", question.Score, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("QStatues", question.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("QExamId", question.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.ExecuteAsync("QuestionPackage.UpdateQuestion", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
