using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class QuestionOptionService : IQuestionOptionService
    {
        private readonly IQuestionOptionRepository _questionOptionRepository;

        public QuestionOptionService(IQuestionOptionRepository questionOptionRepository)
        {
            _questionOptionRepository = questionOptionRepository;
        }

        public bool CreateQuestionOption(QuestionOption questionOption)
        {
            return _questionOptionRepository.CreateQuestionOption(questionOption);
        }

        public bool DeleteQuestionOption(int id)
        {
            return _questionOptionRepository.DeleteQuestionOption(id);
        }

        public List<QuestionOption> GetAllQuestionOption()
        {
            return _questionOptionRepository.QuestionsOptions();
        }

        public bool UpdateQuestionOption(QuestionOption questionOption)
        {
            return _questionOptionRepository.UpdateQuestionOption(questionOption);
        }
    }
}
