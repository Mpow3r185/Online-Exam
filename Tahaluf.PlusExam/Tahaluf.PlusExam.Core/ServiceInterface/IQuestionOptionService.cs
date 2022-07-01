using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface IQuestionOptionService
    {
        // Get QuestionsOptions
        List<QuestionOption> GetQuestionsOptions();

        // Create QuestionsOptions
        bool CreateQuestionOption(QuestionOption questionOption);

        // Update QuestionsOptions
        bool UpdateQuestionOption(QuestionOption questionOption);

        // Delete QuestionsOptions
        bool DeleteQuestionOption(int id);

        // Get QuestionOption By Question Id
        List<QuestionOption> GetQuestionOptionByQuestionId(int qid);
    }
}
