using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface IQuestionOptionService
    {
        //Get All QuestionOption
        List<QuestionOption> GetAllQuestionOption();
        //Create
        bool CreateQuestionOption(QuestionOption questionOption);
        //Update
        bool UpdateQuestionOption(QuestionOption questionOption);
        //Delete
        bool DeleteQuestionOption(int id);
    }
}
