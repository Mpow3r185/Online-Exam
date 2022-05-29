using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IQuestionOptionRepository
    {
        // Get QuestionsOptions
        List<QuestionOption> GetQuestionsOptions();

        // Create QuestionsOptions
        bool CreateQuestionOption(QuestionOption questionOption);

        // Update QuestionsOptions
        bool UpdateQuestionOption(QuestionOption questionOption);

        // Delete QuestionsOptions
        bool DeleteQuestionOption(int id);
    }
}
