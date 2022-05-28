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
        private readonly IDbContext _dbContext;
        public QuestionOptionRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public bool CreateQuestionOption(QuestionOption questionOption)
        {
            var p = new DynamicParameters();
            p.Add("OContent", questionOption.OptionContent, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("OQuestionId", questionOption.QuestionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
           
            var result = _dbContext.Coonection.ExecuteAsync("QuestionOptionPackage.CreateQuestionOption", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteQuestionOption(int id)
        {
            var p = new DynamicParameters();
            p.Add("Oid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Coonection.ExecuteAsync("QuestionOptionPackage.DeleteQuestionOption", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<QuestionOption> GetAllQuestionOption()
        {
            IEnumerable<QuestionOption> result = _dbContext.Coonection.Query<QuestionOption>("QuestionOptionPackage.GetAllQuestionOption", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateQuestionOption(QuestionOption questionOption)
        {
            var p = new DynamicParameters();
            p.Add("Oid", questionOption.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("OContent", questionOption.OptionContent, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("OQuestionId", questionOption.QuestionId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Coonection.ExecuteAsync("QuestionOptionPackage.UpdateQuestionOption", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
