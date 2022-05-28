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
        private readonly IDbContext _dbContext;
        public ResultRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public bool CreateResult(Result result)
        {
            var p = new DynamicParameters();
            p.Add("RQuestionOptionId", result.QuestionOptionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RAccountId", result.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var QResult = _dbContext.Coonection.ExecuteAsync("ResultPackage.CreateResult", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteResult(int id)
        {
            var p = new DynamicParameters();
            p.Add("Rid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Coonection.ExecuteAsync("ResultPackage.DeleteResult", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Result> GetAllResult()
        {
            IEnumerable<Result> result = _dbContext.Coonection.Query<Result>("ResultPackage.GetAllResult", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateResult(Result result)
        {
            var p = new DynamicParameters();
            p.Add("Rid", result.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RQuestionOptionId", result.QuestionOptionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RAccountId", result.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var QResult = _dbContext.Coonection.ExecuteAsync("ResultPackage.UpdateResult", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
