using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface ICorrectAnswerRepository
    {
        //Get All Correct Answers
        List<CorrectAnswer> GetAll();
        //Create
        bool CreateCorrectAnswer(CorrectAnswer correctAnswer);
        //Update
        bool UpdateCorrectAnswer(CorrectAnswer correctAnswer);
        //Delete
        bool DeleteCorrectAnswer(int id);
    }
}
