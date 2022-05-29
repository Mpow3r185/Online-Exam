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
        private readonly IScoreRepository _scoreRepository;
        public ScoreService(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;

        }
        public bool CreateScore(Score score)
        {
            return _scoreRepository.CreateScore(score);
        }

        public bool DeleteScore(int id)
        {
            return _scoreRepository.DeleteScore(id);
        }

        public List<Score> GetAll()
        {
            return _scoreRepository.GetScores();
        }

        public bool UpdateScore(Score score)
        {
            return _scoreRepository.UpdateScore(score);
        }
    }
}
