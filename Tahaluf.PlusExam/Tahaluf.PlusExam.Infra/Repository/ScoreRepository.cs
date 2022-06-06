using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.GenericInterface;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Infra.Generic;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class ScoreRepository : IScoreRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        private readonly IGenericCRUD<Score> genericCRUD;
        #endregion Fields

        #region Constructor
        public ScoreRepository(IDbContext _dbContext)
        {
            genericCRUD = new GenericCRUD<Score>(_dbContext);
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetScores
        // Get Scores
        public List<Score> GetScores()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetScores

        #region CreateScore
        // Create Score
        public bool CreateScore(Score score)
        {
            return genericCRUD.Create(score);
        }
        #endregion CreateScore

        #region UpdateScore
        // Update Score
        public bool UpdateScore(Score score)
        {
            return genericCRUD.Update(score);
        }
        #endregion UpdateScore

        #region DeleteScore
        // Delete Score
        public bool DeleteScore(int id)
        {
            return genericCRUD.Delete(id);
        }
        #endregion DeleteScore

        #endregion CRUD_Operation
    }
}

