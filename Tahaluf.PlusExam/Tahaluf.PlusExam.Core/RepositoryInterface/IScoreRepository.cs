using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IScoreRepository
    {
        // Get Scores
        List<Score> GetScores();

        // Create Score
        bool CreateScore(Score score);

        // Update Score
        bool UpdateScore(Score score);

        // Delete Score
        bool DeleteScore(int id);
    }
}
