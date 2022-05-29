using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface ICorrectAnswerService
    {
        //Get All Correct Answers
        List<CorrectAnswer> GetCorrectAnswers();
        //Create
        bool CreateCorrectAnswer(CorrectAnswer correctAnswer);
        //Update
        bool UpdateCorrectAnswer(CorrectAnswer correctAnswer);
        //Delete
        bool DeleteCorrectAnswer(int id);
    }
}
