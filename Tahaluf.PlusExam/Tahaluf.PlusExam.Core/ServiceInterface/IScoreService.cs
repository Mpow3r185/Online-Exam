using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface IScoreService
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
