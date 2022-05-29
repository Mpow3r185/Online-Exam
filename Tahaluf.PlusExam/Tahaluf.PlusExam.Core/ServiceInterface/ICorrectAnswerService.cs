using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface ICorrectAnswerService
    {
        // Get Correct Answers
        List<CorrectAnswer> GetCorrectAnswers();

        // Create Correct Answer
        bool CreateCorrectAnswer(CorrectAnswer correctAnswer);

        // Update Correct Answer
        bool UpdateCorrectAnswer(CorrectAnswer correctAnswer);

        // Delete Correct Answer
        bool DeleteCorrectAnswer(int id);
    }
}
