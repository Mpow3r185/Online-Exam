using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface IQuestionService
    {
        // Get Questions
        List<Question> GetQuestions();

        // Create Question
        bool CreateQuestion(Question question);

        // Update Question
        bool UpdateQuestion(Question question);

        // Delete Question
        bool DeleteQuestion(int id);

        // Get Questions By Exam Id
        List<Question> GetQeustionsByExamId(int exid);
        
        // Get Questions Details By Exam Id
        List<QuestionsDetailsDTO> GetQeustionsDetailsByExamId(int exid);
        
        // Get All Questions Details 
        List<QuestionsDetailsDTO> GetAllQeustionsDetails();
    }
}
