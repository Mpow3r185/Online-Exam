using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IScoreRepository
    {
        //Get All Scores
        List<Score> GetAll();
        //Create
        bool CreateScore(Score score);
        //Update
        bool UpdateScore(Score score);
        //Delete
        bool DeleteScore(int id);
    }
}
