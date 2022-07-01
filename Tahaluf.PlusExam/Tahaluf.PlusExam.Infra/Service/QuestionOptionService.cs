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
        #region Fields
        private readonly IQuestionOptionRepository _questionOptionRepository;
        #endregion Fields

        #region Constructor
        public QuestionOptionService(IQuestionOptionRepository questionOptionRepository)
        {
            _questionOptionRepository = questionOptionRepository;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateQuestionOption
        public bool CreateQuestionOption(QuestionOption questionOption)
        {
            return _questionOptionRepository.CreateQuestionOption(questionOption);
        }
        #endregion CreateQuestionOption

        #region DeleteQuestionOption
        public bool DeleteQuestionOption(int id)
        {
            return _questionOptionRepository.DeleteQuestionOption(id);
        }
        #endregion DeleteQuestionOption

        #region GetQuestionsOptions
        public List<QuestionOption> GetQuestionsOptions()
        {
            return _questionOptionRepository.GetQuestionsOptions();
        }
        #endregion GetQuestionsOptions

        #region UpdateQuestionOption
        public bool UpdateQuestionOption(QuestionOption questionOption)
        {
            return _questionOptionRepository.UpdateQuestionOption(questionOption);
        }
        #endregion UpdateQuestionOption

        #endregion CRUD_Operation

        public List<QuestionOption> GetQuestionOptionByQuestionId(int qid)
        {
            return _questionOptionRepository.GetQuestionOptionByQuestionId(qid);
        }
    }
}
