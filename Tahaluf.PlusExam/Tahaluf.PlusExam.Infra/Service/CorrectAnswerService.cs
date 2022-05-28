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
        private readonly ICorrectAnswerRepository _correctAnswerRepository;
        public CorrectAnswerService(ICorrectAnswerRepository correctAnswerRepository)
        {
            _correctAnswerRepository = correctAnswerRepository; 

        }
        public bool CreateCorrectAnswer(CorrectAnswer correctAnswer)
        {
            return _correctAnswerRepository.CreateCorrectAnswer(correctAnswer);
        }

        public bool DeleteCorrectAnswer(int id)
        {
            return _correctAnswerRepository.DeleteCorrectAnswer(id);
        }

        public List<CorrectAnswer> GetAll()
        {
            return _correctAnswerRepository.GetAll();
        }

        public bool UpdateCorrectAnswer(CorrectAnswer correctAnswer)
        {
            return _correctAnswerRepository.UpdateCorrectAnswer(correctAnswer);
        }
    }
}
