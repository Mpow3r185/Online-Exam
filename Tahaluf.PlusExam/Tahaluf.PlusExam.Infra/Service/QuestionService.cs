using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }


        public bool CreateQuestion(Question question)
        {
            return _questionRepository.CreateQuestion(question);
        }

        public bool DeleteQuestion(int id)
        {
            return _questionRepository.DeleteQuestion(id);
        }

        public List<Question> GetAllQuestion()
        {
            return _questionRepository.GetQuestions();
        }

        public bool UpdateQuestion(Question question)
        {
            return _questionRepository.UpdateQuestion(question);
        }
    }
}
