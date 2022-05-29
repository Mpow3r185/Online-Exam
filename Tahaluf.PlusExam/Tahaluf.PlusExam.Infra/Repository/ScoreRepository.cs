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
    public class ScoreRepository : IScoreRepository
    {
        private readonly IDbContext _dbContext;
        public ScoreRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        // Get All Scores
        public List<Score> GetScores()
        {
            IEnumerable<Score> result = _dbContext.Connection.Query<Score>("ScorePackage.GetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        // Create
        public bool CreateScore(Score score)
        {
            var p = new DynamicParameters();
            p.Add("SCGRADE", score.Grade, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("SCSTATUS", score.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EXID", score.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ACCID", score.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("ScorePackage.CreateScore", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        //Update
        public bool UpdateScore(Score score)
        {
            var p = new DynamicParameters();
            p.Add("SCOREID", score.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("SCGRADE", score.Grade, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("SCSTATUS", score.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EXID", score.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ACCID", score.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("ScorePackage.UpdateScore", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        //Delete
        public bool DeleteScore(int id)
        {
            var p = new DynamicParameters();
            p.Add("SCOREID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("ScorePackage.DeleteScore", p, commandType: CommandType.StoredProcedure);
            return true;
        }

    }
}
