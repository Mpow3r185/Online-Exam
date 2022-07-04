using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class ScoreService : IScoreService
    {
        #region Fields
        private readonly IScoreRepository _scoreRepository;
        #endregion Fields

        #region Constructor
        public ScoreService(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateScore
        public bool CreateScore(Score score)
        {
            return _scoreRepository.CreateScore(score);
        }
        #endregion CreateScore

        #region DeleteScore
        public bool DeleteScore(int id)
        {
            return _scoreRepository.DeleteScore(id);
        }
        #endregion DeleteScore

        #region GetScores
        public List<Score> GetScores()
        {
            return _scoreRepository.GetScores();
        }
        #endregion GetScores

        #region UpdateScore
        public bool UpdateScore(Score score)
        {
            return _scoreRepository.UpdateScore(score);
        }
        #endregion UpdateScore

        #endregion CRUD_Operation

        public void CalculateScore(int accid, int exid)
        {
            _scoreRepository.CalculateScore(accid, exid);
        }

        public Score GetScoreByExamIdAndAccountId(Score score)
        {
            return _scoreRepository.GetScoreByExamIdAndAccountId(score);
        }
    }
}
