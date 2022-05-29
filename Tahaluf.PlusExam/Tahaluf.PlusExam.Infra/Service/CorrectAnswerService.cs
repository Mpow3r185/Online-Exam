using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class CorrectAnswerService : ICorrectAnswerService
    {
        #region Fields
        private readonly ICorrectAnswerRepository _correctAnswerRepository;
        #endregion Fields

        #region Constructor
        public CorrectAnswerService(ICorrectAnswerRepository correctAnswerRepository)
        {
            _correctAnswerRepository = correctAnswerRepository; 
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateCorrectAnswer
        public bool CreateCorrectAnswer(CorrectAnswer correctAnswer)
        {
            return _correctAnswerRepository.CreateCorrectAnswer(correctAnswer);
        }
        #endregion CreateCorrectAnswer

        #region DeleteCorrectAnswer
        public bool DeleteCorrectAnswer(int id)
        {
            return _correctAnswerRepository.DeleteCorrectAnswer(id);
        }
        #endregion DeleteCorrectAnswer

        #region GetCorrectAnswers
        public List<CorrectAnswer> GetCorrectAnswers()
        {
            return _correctAnswerRepository.GetCorrectAnswers();
        }
        #endregion GetCorrectAnswers

        #region UpdateCorrectAnswer
        public bool UpdateCorrectAnswer(CorrectAnswer correctAnswer)
        {
            return _correctAnswerRepository.UpdateCorrectAnswer(correctAnswer);
        }
        #endregion UpdateCorrectAnswer

        #endregion CRUD_Operation
    }
}
