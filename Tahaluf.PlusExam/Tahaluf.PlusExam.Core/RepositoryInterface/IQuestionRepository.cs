using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IQuestionRepository
    {
        //Get All Question
        List<Question> GetAllQuestion();
        //Create
        bool CreateQuestion(Question question);
        //Update
        bool UpdateQuestion(Question question);
        //Delete
        bool DeleteQuestion(int id);
    }
}
