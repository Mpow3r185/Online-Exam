using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class QuestionService : IQuestionService
    {
        #region Fields
        private readonly IQuestionRepository _questionRepository;
        #endregion Fields

        #region Constructor
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateQuestion
        public bool CreateQuestion(Question question)
        {
            return _questionRepository.CreateQuestion(question);
        }
        #endregion CreateQuestion

        #region DeleteQuestion
        public bool DeleteQuestion(int id)
        {
            return _questionRepository.DeleteQuestion(id);
        }
        #endregion CreateQuestion

        #region GetQuestions
        public List<Question> GetQuestions()
        {
            return _questionRepository.GetQuestions();
        }
        #endregion GetQuestions

        #region UpdateQuestion
        public bool UpdateQuestion(Question question)
        {
            return _questionRepository.UpdateQuestion(question);
        }

        #endregion UpdateQuestion

        #endregion CRUD_Operation

        public List<Question> GetQeustionsByExamId(int exid)
        {
            return _questionRepository.GetQeustionsByExamId(exid);
        }
        // Get Qeustions Details By ExamId
        public List<QuestionsDetailsDTO> GetQeustionsDetailsByExamId(int exid)
        {

            return _questionRepository.GetQeustionsDetailsByExamId(exid);
        }

        // Get All Qeustions Details
        public List<QuestionsDetailsDTO> GetAllQeustionsDetails()
        {
            return _questionRepository.GetAllQeustionsDetails();
        }

        // Get Questions And Exams
        public List<QuestionExamDTO> GetQuestionsAndExams()
        {
            return _questionRepository.GetQuestionsAndExams();
        }
    }
}
