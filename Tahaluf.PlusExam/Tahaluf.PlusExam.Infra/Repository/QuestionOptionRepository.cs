using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class QuestionOptionRepository : IQuestionOptionRepository
    {
        #region Fields
         private readonly IGenericCRUD<QuestionOption> genericCRUD;
        #endregion Fields

        #region Constructor
        public QuestionOptionRepository(IDbContext DbContext)
        {
            genericCRUD = new GenericCRUD<QuestionOption>(DbContext);
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateQuestionOption
        public bool CreateQuestionOption(QuestionOption questionOption)
        {
            return genericCRUD.Create(questionOption);
        }
        #endregion CreateQuestionOption

        #region DeleteQuestionOption
        public bool DeleteQuestionOption(int id)
        {
            return genericCRUD.Delete(id);
        }
        #endregion DeleteQuestionOption

        #region GetQuestionsOptions
        public List<QuestionOption> GetQuestionsOptions()
        {
           return genericCRUD.GetAll();
        }
        #endregion GetQuestionsOptions

        #region UpdateQuestionOption
        public bool UpdateQuestionOption(QuestionOption questionOption)
        {
            return genericCRUD.Update(questionOption);
        }
        #endregion UpdateQuestionOption

        #endregion CRUD_Operation
    }
}
