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
    public class QuestionRepository : IQuestionRepository
    {
        #region Fields
         private readonly IGenericCRUD<Question> genericCRUD;
        #endregion Fields

        #region Constructor
        public QuestionRepository(IDbContext DbContext)
        {
            genericCRUD = new GenericCRUD<Question>(DbContext);  
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateQuestion
        public bool CreateQuestion(Question question)
        {
            return genericCRUD.Create(question);
        }
        #endregion CreateQuestion

        #region DeleteQuestion
        public bool DeleteQuestion(int id)
        {
            return genericCRUD.Delete(id);
        }
        #endregion DeleteQuestion

        #region GetQuestions
        public List<Question> GetQuestions()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetQuestions

        #region UpdateQuestion
        public bool UpdateQuestion(Question question)
        {
            return genericCRUD.Update(question);
        }
        #endregion UpdateQuestion

        #endregion CRUD_Operation
    }
}
