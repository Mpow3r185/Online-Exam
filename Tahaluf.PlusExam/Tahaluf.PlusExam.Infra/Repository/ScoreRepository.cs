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
        #region Fields
        private readonly IDbContext _dbContext;
        #endregion Fields

        #region Constructor
        public ScoreRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetScores
        // Get Scores
        public List<Score> GetScores()
        {
            return _dbContext.Connection.Query<Score>(
                "ScorePackage.GetAll",
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion GetScores

        #region CreateScore
        // Create Score
        public bool CreateScore(Score score)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SCGRADE",
                score.Grade, 
                dbType: DbType.Double, 
                direction: ParameterDirection.Input);

            parameters.Add("SCSTATUS",
                score.Status,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("EXID",
                score.ExamId, 
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("ACCID",
                score.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            _dbContext.Connection.ExecuteAsync(
                "ScorePackage.CreateScore", parameters,
                commandType: CommandType.StoredProcedure);
            
            return true;
        }
        #endregion CreateScore

        #region UpdateScore
        // Update Score
        public bool UpdateScore(Score score)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SCOREID", 
                score.Id, 
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("SCGRADE", 
                score.Grade, 
                dbType: DbType.Double,
                direction: ParameterDirection.Input);

            parameters.Add("SCSTATUS",
                score.Status, dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("EXID",
                score.ExamId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("ACCID",
                score.AccountId, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            _dbContext.Connection.ExecuteAsync(
                "ScorePackage.UpdateScore", parameters, 
                commandType: CommandType.StoredProcedure);
            
            return true;
        }
        #endregion UpdateScore

        #region DeleteScore
        // Delete Score
        public bool DeleteScore(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SCOREID", 
                id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            _dbContext.Connection.ExecuteAsync(
                "ScorePackage.DeleteScore", parameters, 
                commandType: CommandType.StoredProcedure);
            
            return true;
        }
        #endregion DeleteScore

        #endregion CRUD_Operation
    }
}
